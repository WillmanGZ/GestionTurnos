using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GestionTurnos.Web.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Cargar y leer manualmente la configuración del appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtener la cadena de conexión
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Crea el objeto de configuración y usa PGSQL como proveedor
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            // Retorna una instancia funcional del DbContext
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
