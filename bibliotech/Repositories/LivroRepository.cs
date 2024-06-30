using bibliotech.Data;
using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotech.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro> GetById(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task Add(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
