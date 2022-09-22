using FluentValidation;
using RP.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.Domain.DTO.Product;
namespace Application.Validator.Product.Extensions.Update
{
    public class DeleteId : AbstractValidator<DeleteProductDTO>
    {
        public DeleteId()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Id no puede ser nulo")
                .NotEmpty().WithMessage("El Id no puede ser vacío")
                .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de Id incorrecto");
        }
    }
}
