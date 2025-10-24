using GestionTurnos.Web.Data.Entities;
using GestionTurnos.Web.Interfaces;

namespace GestionTurnos.Web.Services
{
    public class AfiliadoService : IAfiliadoServicio
    {
        private readonly IAfiliadoRepository _afiliadoRepository;

        public AfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            _afiliadoRepository = afiliadoRepository;
        }

        public async Task<List<Afiliado>> GetAllAfiliados()
        {
            return await _afiliadoRepository.GetAll();
        }

        public async Task<Afiliado?> GetAfiliadoById(int id)
        {
            if (id == null) return null;
            return await _afiliadoRepository.GetById(id);
        }


        public Task<bool> CreateAfiliado(Afiliado afiliado)
        {
            if (string.IsNullOrEmpty(afiliado.Nombre) ||
                string.IsNullOrEmpty(afiliado.Documento) ||
                string.IsNullOrEmpty(afiliado.Sexo) ||
                string.IsNullOrEmpty(afiliado.Correo) ||
                string.IsNullOrEmpty(afiliado.Telefono) ||
                string.IsNullOrEmpty(afiliado.FotoUrl)) return Task.FromResult(false);

            return _afiliadoRepository.Create(afiliado);
        }

        public Task<bool> UpdateAfiliado(Afiliado afiliado)
        {
            if (string.IsNullOrEmpty(afiliado.Nombre) ||
                string.IsNullOrEmpty(afiliado.Documento) ||
                string.IsNullOrEmpty(afiliado.Sexo) ||
                string.IsNullOrEmpty(afiliado.Correo) ||
                string.IsNullOrEmpty(afiliado.Telefono) ||
                string.IsNullOrEmpty(afiliado.FotoUrl)) return Task.FromResult(false);

            return _afiliadoRepository.Update(afiliado);
        }

        public async Task<bool> DeleteAfiliado(int id)
        {
            if (id == null) return false;
            return await _afiliadoRepository.Delete(id);
        }
    }
}
