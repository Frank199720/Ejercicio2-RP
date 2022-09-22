using MediatR;
using RP.Domain.DTO.Product;
using RP.Domain.Interfaces.Services;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Application.Handlers.Command.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductDTO, ApiResponse<DeleteProductDTO>>
    {
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService productService) => _productService = productService;
        public async Task<ApiResponse<DeleteProductDTO>> Handle(DeleteProductDTO request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request);
            return new ApiResponse<DeleteProductDTO>(request, $"El producto {request.Id} se ha eliminado de la base de datos");

        }
    }
}
