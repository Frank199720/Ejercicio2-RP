using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product.Extensions.Update
{
    internal class UpdateStock : AbstractValidator<UpdateProductDTO>
    {
        public UpdateStock()
        {
            RuleFor(x => x.Stock)
                .Cascade(CascadeMode.Stop)
                .Must(u => u >= 0).WithMessage("El stock de ingreso no puede ser negativo");
        }
    }
}
