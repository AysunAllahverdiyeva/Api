using JawelryStore.Persistance.EntityFrameworks;
using JawelryStore.Persistance.EntityFrameworks.Repositories;
using JawelryStore.Persistance.Interceptors;
using JewelryStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance;

public static class  ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("local");

        services
            .AddDbContext<JewelryStoreContext>(options => options
            .UseSqlServer(connectionString)
            .AddInterceptors(new UpdateBaseEntityInterceptor()));
        services.AddHttpContextAccessor();
        services.AddScoped<IUnitOfWork, UnitOfwork>();
        
    }
}
