using bibliotech.Interfaces;
using bibliotech.Models;

namespace bibliotech.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _usuarioRepository.GetById(id);
        }

        public async Task Add(Usuario usuario)
        {
            await _usuarioRepository.Add(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            await _usuarioRepository.Update(usuario);
        }

        public async Task Delete(int id)
        {
            await _usuarioRepository.Delete(id);
        }
    }
}
