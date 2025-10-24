using GestionTurnos.Web.Data.Entities;

namespace GestionTurnos.Web.Interfaces
{
    public interface IAfiliadoRepository
    {
        Task<List<Afiliado>> GetAll();
        Task<Afiliado?> GetById(int id);
        Task<bool> Create(Afiliado afiliado);
        Task<bool> Update(Afiliado afiliado);
        Task<bool> Delete(int id);
    }
}
