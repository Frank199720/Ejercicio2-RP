using AutoMapper;
using MediatR;
using RP.Application.Querys;
using RP.Domain.DTO.Product;
using RP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Application.Handlers.Query
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetProductHandler(IProductService medicoService, IMapper mapper)
        {
            _productService = medicoService;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDTO>(await _productService.GetProductByIdAsync(request.Id));
        }
    }
}
