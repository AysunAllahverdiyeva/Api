using FluentValidation;
using JewelryStore.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Validators.FluentValidations
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
    }
}
