using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Entities;

namespace Product.Application.Interfaces
{
    public interface IProductRepositories
    {
        // CREATE
        Task<Produc> AddAsync(Produc product);

        // READ
        Task<IEnumerable<Produc>> GetAllAsync();
        Task<Produc?> GetByIdAsync(int id);
        Task<IEnumerable<Produc>> GetByCategoryIdAsync(int categoryId);

        // UPDATE
        Task<Produc?> UpdateAsync(Produc product);

        // DELETE
        Task<bool> DeleteAsync(int id);


    }

}
