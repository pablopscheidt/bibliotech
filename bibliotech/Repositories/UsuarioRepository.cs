using bibliotech.Data;
using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotech.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
