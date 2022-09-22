using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product.Extensions.Add
{
    internal class AddStock : AbstractValidator<CreateProductDTO>
    {
        public AddStock()
        {
            RuleFor(x => x.Stock)
                .Cascade(CascadeMode.Stop)
                .Must(u => u >= 0).WithMessage("El stock de ingreso no puede ser negativo");
        }
    }
}
