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
        Task<Produc> AddAsync(Produc product);
        Task<IEnumerable<Produc>> GetByCategoryIdAsync(int categoryId);
    }
}
