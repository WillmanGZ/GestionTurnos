using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GestionTurnos.Web.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            // Cargar variables del archivo .env
            DotNetEnv.Env.Load();

            var host = Environment.GetEnvironmentVariable("DB_HOST_MIGRATIONS");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var name = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASS");

            // Construir la cadena de conexión dinámicamente
            var connectionString = $"Host={host};Port={port};Database={name};Username={user};Password={pass}";

            // FORMA SIN .ENV
            //// Registrar el contexto
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseNpgsql(connectionString));


            //// Cargar y leer manualmente la configuración del appsettings.json
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //// Obtener la cadena de conexión
            //var connectionString = config.GetConnectionString("DefaultConnection");

            // Crea el objeto de configuración y usa PGSQL como proveedor

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            // Retorna una instancia funcional del DbContext
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
