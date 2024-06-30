using bibliotech.Models;

namespace bibliotech.Interfaces
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> GetAll();
        Task<Emprestimo> GetById(int id);
        Task Add(Emprestimo emprestimo);
        Task Update(Emprestimo emprestimo);
        Task Delete(int id);
    }
}
