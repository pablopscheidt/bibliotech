using bibliotech.Models;

namespace bibliotech.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetAll();
        Task<Livro> GetById(int id);
        Task Add(Livro livro);
        Task Update(Livro livro);
        Task Delete(int id);
    }
}
