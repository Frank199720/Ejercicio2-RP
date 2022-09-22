using RP.Domain.Entities;
using RP.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByName(string productName);
        Task<int> GetCount();

    }
}
