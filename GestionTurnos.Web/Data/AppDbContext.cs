using GestionTurnos.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Afiliado> Afiliados { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
