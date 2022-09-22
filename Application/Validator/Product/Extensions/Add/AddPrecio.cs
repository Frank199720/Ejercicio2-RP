using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product.Extensions.Add
{
    public class AddPrecio : AbstractValidator<CreateProductDTO>
    {
        public AddPrecio()
        {
            RuleFor(x => x.Precio)
                .Cascade(CascadeMode.Stop)
                .Must(u => u >= 0).WithMessage("El precio no puede ser negativo");
        }
    }
}
