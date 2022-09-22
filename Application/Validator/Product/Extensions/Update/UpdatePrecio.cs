using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product.Extensions.Update
{
    public class UpdatePrecio : AbstractValidator<UpdateProductDTO>
    {
        public UpdatePrecio()
        {
            RuleFor(x => x.Precio)
                .Cascade(CascadeMode.Stop)
                .Must(u => u >= 0).WithMessage("El precio no puede ser negativo");
        }
    }
}
