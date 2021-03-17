using System.Collections.Generic;
using System.Threading.Tasks;
using Wevo.Domain;

namespace Wevo.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario[]> GetAllAsync();
        Task<Usuario> GetAsync(int Id);
        Task Add<T>(T entity) where T : class;
        Task<Usuario> Update<T>(int Id, T entity) where T : class;
        Task<bool> Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}