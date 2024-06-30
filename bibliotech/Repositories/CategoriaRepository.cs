using bibliotech.Data;
using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotech.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BibliotecaContext _context;

        public CategoriaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetById(int id) => await _context.Categorias.FindAsync(id);

        public async Task Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
