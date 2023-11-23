using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetoLibreria.Literals;
using RetoLibreria.Modelos;

namespace RetoLibreria.Configurations
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            // var connectionString = Environment.GetEnvironmentVariable(RetoLibreriaLiterals.LIBERIA_CONNECTION_STRING);
            var connectionString = "Server=localhost,1433;Database=Libreria_DB;User Id=sa;Password=1017256448itm*;TrustServerCertificate=true;";
            services.AddDbContext<DataContext>(options =>
            {
                      options.UseSqlServer(connectionString);
            });
            return services;

        }

    }
}

