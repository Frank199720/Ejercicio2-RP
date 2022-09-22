using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.Domain.DTO.Product;

namespace Application.Validator.Product.Extensions.Update
{
    public class UpdateNombre : AbstractValidator<UpdateProductDTO>
    {
        public UpdateNombre()
        {
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El nombre del producto no puede ser nulo")
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacío");
        }
    }
}
