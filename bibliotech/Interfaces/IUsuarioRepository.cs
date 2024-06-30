using bibliotech.Models;

namespace bibliotech.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }
}
