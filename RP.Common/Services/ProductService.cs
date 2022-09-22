using AutoMapper;
using RP.Domain.DTO.Product;
using RP.Domain.Entities;
using RP.Domain.Exceptions.Core.Persistence;
using RP.Domain.Interfaces.Repository;
using RP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using RP.Domain.Entities.Base;
using RP.Domain.Interfaces.Managment;
using RP.Domain.Exceptions.Core.Pagination;

namespace RP.Common.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        internal readonly IMapper _mapper;
        protected IMapper Mapper => _mapper;

        public int RowCount => _iCount;

        private readonly IDataShapeHelper<ProductDTO> _dataShaperHelper;
        internal int _iCount;
        
        public ProductService(IProductRepository productRepository , IMapper mapper , IDataShapeHelper<ProductDTO> dataShapeHelper)
        {
            _productRepository = productRepository;
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _dataShaperHelper = dataShapeHelper;
        }

        public async Task<int> CreateProductAsync(CreateProductDTO productDTO)
        {
            

            var ifExists = await _productRepository.GetByName(productDTO.Nombre);

            if(ifExists != null)
            {
                throw new EntityAlreadyExistException(productDTO.GetType(), $"Nombre : {productDTO.Nombre}");
            }
            else
            {
                var entity = new Product
                {
                    Nombre = productDTO.Nombre,
                    Precio = productDTO.Precio,
                    Stock = productDTO.Stock
                };
                return await _productRepository.AddAsync(entity);
            }
        }
    
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var ifExistsById = await _productRepository.GetByIdAsync(id);
            if (ifExistsById != null)
            {
                return Mapper.Map<ProductDTO>(ifExistsById);
            }
            else
            {
                throw new EntityNotFoundException($"No existe el producto con ID: {id}");
            }

        }

        public async Task<int> UpdateProductAsync(UpdateProductDTO productDTO)
        {
            var ifExistsById = await _productRepository.GetByIdAsync(productDTO.Id);
            if (ifExistsById != null)
            {
                var ifExists = await _productRepository.GetByName(productDTO.Nombre);

                if (ifExists != null)
                {
                    throw new EntityAlreadyExistException(productDTO.GetType(), $"Nombre : {productDTO.Nombre}");
                }
                else
                {
                    var entity = new Product
                    {
                        Nombre = productDTO.Nombre,
                        Precio = productDTO.Precio,
                        Stock = productDTO.Stock,
                        Id = productDTO.Id
                    };
                    return await _productRepository.UpdateAsync(entity);
                }
            }
            else
            {
                throw new EntityNotFoundException($"No existe el producto con ID: {productDTO.Id}");
            }
            
        }

        public async Task<int> DeleteProductAsync(DeleteProductDTO productDTO)
        {
            var ifExistsById = await _productRepository.GetByIdAsync(productDTO.Id);

            if (ifExistsById != null)
            {
                return await _productRepository.DeleteAsync(productDTO.Id);
            }
            else
            {
                throw new EntityNotFoundException($"No existe el producto con ID: {productDTO.Id}");
            }
        }

        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedProductAsync(int pageNumber, int pageSize)
        {
            _iCount = await  _productRepository.GetCount();

            if (pageNumber < 1 || (pageNumber > ((int)Math.Ceiling(_iCount / (double)pageSize))))
                throw new PageRowIndexNotFoundException(pageNumber);

            if (pageSize < 10)
                throw new PageRowMinimumException(pageSize);

            if (pageSize > 50)
                throw new PageRowMaximumException(pageSize);
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
            return await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<ProductDTO>>(products));
        }
    }
}
