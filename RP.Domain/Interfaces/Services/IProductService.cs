using RP.Domain.DTO.Product;
using RP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
        public int RowCount { get; }
        Task<int> CreateProductAsync(CreateProductDTO productDTO);
        Task<int> UpdateProductAsync(UpdateProductDTO productDTO);

        Task<IEnumerable<ShapedEntityDTO>> GetPagedProductAsync(int pageNumber, int pageSize);

        Task<int> DeleteProductAsync(DeleteProductDTO productDTO);
    }
}
