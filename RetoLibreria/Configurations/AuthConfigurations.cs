using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RetoLibreria.Modelos;

namespace RetoLibreria.Configurations
{
    public static class AuthConfigurations
    {
        public static IServiceCollection SetRetoLibreriaAuthConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;

                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;


                // Configuración de politicas de contraseñas, bloqueo de cuentas, etc .
            }).AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    /*ValidateIssuer = "tu_issuer",
                    ValidateAudience = "tu_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta")),

                    ClockSkew = TimeSpan.Zero

                    // Evita un desfase de tiempa (opcional)*/

                };
                
            });
            return services;
        }
    }
}
