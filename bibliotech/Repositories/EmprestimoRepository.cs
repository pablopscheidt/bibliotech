using bibliotech.Data;
using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotech.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext _context;

        public EmprestimoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Emprestimo>> GetAll()
        {
            return await _context.Emprestimos.Include(e => e.Livro).Include(e => e.Usuario).ToListAsync();
        }

        public async Task<Emprestimo> GetById(int id)
        {
            return await _context.Emprestimos.Include(e => e.Livro).Include(e => e.Usuario).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task Add(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Emprestimo emprestimo)
        {
            _context.Entry(emprestimo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimos.Remove(emprestimo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
