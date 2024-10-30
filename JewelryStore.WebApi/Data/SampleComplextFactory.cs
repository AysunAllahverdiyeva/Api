using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using JawelryStore.Persistance.EntityFrameworks;

namespace JewelryStore.WebApi.Data
{
    
        public class SampleContextFactory : IDesignTimeDbContextFactory<JewelryStoreContext>
        {
            public JewelryStoreContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<JewelryStoreContext>();
                var connectionString = configuration.GetConnectionString("local");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("JawelryStore.Persistance"));


            return new JewelryStoreContext(builder.Options);
            }
        }
    
}
