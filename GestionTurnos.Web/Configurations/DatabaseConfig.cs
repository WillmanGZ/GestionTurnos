using GestionTurnos.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Configurations
{
    public static class DatabaseConfig
    {
        // Método de extensión que se “pega” a IServiceCollection
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Cargar variables del archivo .env
            DotNetEnv.Env.Load();

            // Leer variables de entorno
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var name = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASS");

            // Armar el connection string
            var connectionString = $"Host={host};Port={port};Database={name};Username={user};Password={pass}";

            // Registrar el DbContext en el contenedor de servicios
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Retornar services para poder encadenar más métodos
            return services;
        }
    }

}
