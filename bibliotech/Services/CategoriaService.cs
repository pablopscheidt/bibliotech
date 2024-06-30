using bibliotech.Interfaces;
using bibliotech.Models;

namespace bibliotech.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _categoriaRepository.GetAll();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _categoriaRepository.GetById(id);
        }

        public async Task Add(Categoria categoria)
        {
            await _categoriaRepository.Add(categoria);
        }

        public async Task Update(Categoria categoria)
        {
            await _categoriaRepository.Update(categoria);
        }

        public async Task Delete(int id)
        {
            await _categoriaRepository.Delete(id);
        }
    }
}
