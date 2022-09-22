using MediatR;
using RP.Domain.DTO.Base;
using RP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.DTO.Product
{
    public class CreateProductDTO : CommandDTO, IRequest<ApiResponse<CreateProductDTO>>
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
