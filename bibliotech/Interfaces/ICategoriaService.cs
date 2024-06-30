using bibliotech.Models;

namespace bibliotech.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task Add(Categoria categoria);
        Task Update(Categoria categoria);
        Task Delete(int id);
    }
}
