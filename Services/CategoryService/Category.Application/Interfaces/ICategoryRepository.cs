using Category.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Categor> AddAsync(Categor category);
        Task<Categor?> GetByIdAsync(int id);
        Task<IEnumerable<Categor>> GetAllAsync();
    }
}
