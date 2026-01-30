# 1️⃣ Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 3300

# 2️⃣ Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into the container
COPY . .

# Restore NuGet packages
RUN dotnet restore UserManagement.sln



# Build & publish ApiGateway project
RUN dotnet publish ApiGateway/ApiGateway.csproj -c Release -o /app/publish

# 3️⃣ Final runtime image
FROM base AS final
WORKDIR /app

# Copy the published files
COPY --from=build /app/publish .

# Set the entrypoint to run ApiGateway
ENTRYPOINT ["dotnet", "ApiGateway.dll"]

