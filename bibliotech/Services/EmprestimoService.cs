using bibliotech.Interfaces;
using bibliotech.Models;

namespace bibliotech.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<IEnumerable<Emprestimo>> GetAll()
        {
            return await _emprestimoRepository.GetAll();
        }

        public async Task<Emprestimo> GetById(int id)
        {
            return await _emprestimoRepository.GetById(id);
        }

        public async Task Add(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Add(emprestimo);
        }

        public async Task Update(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Update(emprestimo);
        }

        public async Task Delete(int id)
        {
            await _emprestimoRepository.Delete(id);
        }
    }
}
