using GestionTurnos.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
