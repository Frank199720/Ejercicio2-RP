using MediatR;
using Microsoft.AspNetCore.Http;
using RP.Domain.DTO.Product;
using RP.Domain.Interfaces.Services;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Command.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductDTO, ApiResponse<CreateProductDTO>>
    {
        private readonly IProductService _productService;
        private IHttpContextAccessor _context;
        public CreateProductHandler(IProductService productService, IHttpContextAccessor context)
        {
            _productService = productService;
            _context = context;
        }
   
        public async Task<ApiResponse<CreateProductDTO>> Handle(CreateProductDTO request, CancellationToken cancellationToken)
        {
            var entity = await _productService.CreateProductAsync(request);
            _context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            return new ApiResponse<CreateProductDTO>(request, $"El producto {request.Nombre} se ha creado correctamente");
        }
    }
}
