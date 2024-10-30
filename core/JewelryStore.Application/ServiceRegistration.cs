using FluentValidation;
using JewelryStore.Application.Features.Command;
using JewelryStore.Application.Validators.FluentValidations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(AbstractValidator<AddProductCommand>), typeof(AddProductCommandValidator));
            services.AddScoped(typeof(AbstractValidator<CreateUserCommand>), typeof(CreateUserCommandValidator));
          
        }
    }
}
