using Application.Validator.Product.Extensions.Update;
using FluentValidation;
using RP.Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator()
        {
            Include(new UpdateNombre());
            Include(new UpdatePrecio());
            Include(new UpdateStock());
            Include(new UpdateId());

        }
    }
}
