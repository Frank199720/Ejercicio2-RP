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
    public class DeleteProductDTO : CommandDTO, IRequest<ApiResponse<DeleteProductDTO>>
    {
        //Lo uso porque en el DTO podemos enviar cosas como autoSave , para saber si será una eliminación lógica o física, en este caso por el ejercicio , solo será física.
        public int Id { get; set; }
    }
}
