using GestionTurnos.Web.Data;
using GestionTurnos.Web.Data.Entities;
using GestionTurnos.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Repositories
{
    public class AfiliadoRepository : IAfiliadoRepository
    {
        private readonly AppDbContext _context;

        public AfiliadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Afiliado>> GetAll()
        {
            try
            {
                return await _context.Afiliados.ToListAsync();
            }
            catch (Exception ex)
            {
                return [];
            }

        }

        public async Task<Afiliado?> GetById(int id)
        {
            try
            {
                return await _context.Afiliados.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> Create(Afiliado afiliado)
        {
            try
            {
                await _context.Afiliados.AddAsync(afiliado);
                var results = await _context.SaveChangesAsync();
                return results > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Update(Afiliado afiliado)
        {
            try
            {
                _context.Afiliados.Update(afiliado);
                var results = await _context.SaveChangesAsync();
                return results > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var afiliado = await _context.Afiliados.FindAsync(id);
                if (afiliado == null) return false;

                _context.Afiliados.Remove(afiliado);
                var results = await _context.SaveChangesAsync();
                return results > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
