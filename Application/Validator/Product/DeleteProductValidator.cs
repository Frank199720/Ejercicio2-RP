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
    public class DeleteProductValidator : AbstractValidator<DeleteProductDTO>
    {
        public DeleteProductValidator()
        {
           Include(new DeleteId());
        }
    }
}
