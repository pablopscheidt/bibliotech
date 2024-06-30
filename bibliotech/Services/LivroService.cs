using bibliotech.Interfaces;
using bibliotech.Models;

namespace bibliotech.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _livroRepository.GetAll();
        }

        public async Task<Livro> GetById(int id)
        {
            return await _livroRepository.GetById(id);
        }

        public async Task Add(Livro livro)
        {
            await _livroRepository.Add(livro);
        }

        public async Task Update(Livro livro)
        {
            await _livroRepository.Update(livro);
        }

        public async Task Delete(int id)
        {
            await _livroRepository.Delete(id);
        }
    }
}
