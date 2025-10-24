using GestionTurnos.Web.Models;

namespace GestionTurnos.Web.Interfaces
{
    public interface IAfiliadoServicio
    {
        Task<List<Afiliado>> GetAllAfiliados();
        Task<Afiliado?> GetAfiliadoById(int id);
        Task<bool> CreateAfiliado(Afiliado afiliado);
        Task<bool> UpdateAfiliado(Afiliado afiliado);
        Task<bool> DeleteAfiliado(int id);
    }
}
