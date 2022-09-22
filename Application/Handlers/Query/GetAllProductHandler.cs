using AutoMapper;
using MediatR;
using RP.Application.Querys;
using RP.Domain.Custom;
using RP.Domain.Entities.Base;
using RP.Domain.Interfaces.Managment;
using RP.Domain.Interfaces.Services;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RP.Application.Handlers.Query
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IProductService _productService;

        public GetAllProductHandler(IProductService productService, IMapper mapper, IUriService uriService) =>
            (_mapper, _uriService, _productService) = (mapper, uriService, productService);
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
          
            var _validFilter = _mapper.Map<GetAllProductParameter>(request);            

            var _resultPaged = await _productService.GetPagedProductAsync(_validFilter.PageNumber, _validFilter.PageSize);
            return new ApiResponse<MetaData<ShapedEntityDTO>>(_mapper.Map<PagedList<ShapedEntityDTO>, MetaData<ShapedEntityDTO>>
                (new PagedList<ShapedEntityDTO>(_resultPaged, _validFilter.PageNumber, _validFilter.PageSize
                , _productService.RowCount, _uriService, request.Route)));
        }
    }
}
