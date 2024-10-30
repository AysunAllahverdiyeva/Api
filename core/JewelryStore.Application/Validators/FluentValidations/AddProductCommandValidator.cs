using FluentValidation;
using JewelryStore.Application.Extensions;
using JewelryStore.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Validators.FluentValidations
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(50)
               .CheckNull();


            RuleFor(x => x.Description)
               .NotEmpty()
               .MaximumLength(50)
               .CheckNull();


            RuleFor(x => x.Price)
             .GreaterThan(10)
             .WithMessage("Price must greater than 10");


            RuleFor(x => x.Color)
             .NotEmpty()
             .CheckNull();

        }
    }
}
