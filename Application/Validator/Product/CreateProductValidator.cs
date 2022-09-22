using Application.Validator.Product.Extensions.Add;
using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            Include(new AddNombre());
            Include(new AddPrecio());
            Include(new AddStock());

        }
    }
}
