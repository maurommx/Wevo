using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wevo.Domain;

namespace Wevo.Repository
{
    public abstract class BaseRepository : IUsuarioRepository
    {
        protected DataContext _context;

        public async Task<Usuario> GetAsync(int Id)
        {
            return await _context.Usuarios.Where(u => u.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> GetAllAsync()
        {
            return await _context.Usuarios.ToArrayAsync();
        }

        public async Task Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario> Update<T>(int Id, T entity) where T : class
        {
            var result = await GetAsync(Id);
            _context.Entry(result).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return await GetAsync(Id);
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}