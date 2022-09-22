using MediatR;
using RP.Domain.Custom;
using RP.Domain.DTO.Product;
using RP.Domain.Entities.Base;
using RP.Domain.Parameters;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Application.Querys
{


       

        public class GetAllProductParameter : RequestParameter { }

        public class GetAllProductQuery : IRequest<ApiResponse<MetaData<ShapedEntityDTO>>>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string Route { get; set; }


    }

    public class GetProductQuery : IRequest<ProductDTO>
        {
            public int Id { get; set; }
            public GetProductQuery(int id)
            {
                Id = id;
            }
        }

    

}
