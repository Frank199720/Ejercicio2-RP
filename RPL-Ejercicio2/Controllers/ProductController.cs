using Application.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RP.Application.Querys;
using RP.Domain.Custom;
using RP.Domain.DTO.Product;
using RP.Domain.Entities.Base;
using RP.Domain.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using static RP.Application.Querys.GetProductQuery;

namespace RPL_Ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerResponse(201,"El producto ingresado ha sido creado",typeof(ApiResponse<CreateProductDTO>))]
        public async  Task<ApiResponse<CreateProductDTO>> Add(CreateProductDTO product) => await _mediator.Send(product);

        [HttpPut]
        public async Task<ApiResponse<UpdateProductDTO>> Update(UpdateProductDTO product) => await _mediator.Send(product);
        [HttpGet]
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Get([FromQuery] GetAllProductParameter filter)
        {
            var _response = await _mediator.Send(new GetAllProductQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                Route = Request.Path.Value
            });

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject((_response.Data.Paging.CurrentPage, _response.Data.Paging.PageSize, _response.Data.Paging.TotalCount)));
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id) => await _mediator.Send(new GetProductQuery(id));

        [HttpDelete]
        public async  Task<ApiResponse<DeleteProductDTO>> Delete(DeleteProductDTO product) => await _mediator.Send(product);


    }
}
