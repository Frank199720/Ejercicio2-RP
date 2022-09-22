using MediatR;
using RP.Domain.DTO.Product;
using RP.Domain.Interfaces.Services;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Application.Handlers.Command.Update
{
    public class UpdatePacienteHandler : IRequestHandler<UpdateProductDTO, ApiResponse<UpdateProductDTO>>
    {
        private readonly IProductService _productService;
        public UpdatePacienteHandler( IProductService productService) => _productService = productService;
        public async Task<ApiResponse<UpdateProductDTO>> Handle(UpdateProductDTO request, CancellationToken cancellationToken)
        {
            var entity = await _productService.UpdateProductAsync(request);
            return new ApiResponse<UpdateProductDTO>(request, $"El producto {request.Nombre} se ha actualizado correctamente");
            
        }
    }
}
