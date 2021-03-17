using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wevo.Domain;

namespace Wevo.Repository 
{
    public class UsuarioMemoryRepository : BaseRepository, IUsuarioMemoryRepository
    {
        public UsuarioMemoryRepository(DataContextMemory context)
        {
            _context = context;
        }
    }
}