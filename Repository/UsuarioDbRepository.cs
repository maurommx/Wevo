using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wevo.Domain;

namespace Wevo.Repository
{
    public class UsuarioDbRepository : BaseRepository, IUsuarioDbRepository
    {
        public UsuarioDbRepository(DataContextDb context)
        {
            _context = context;
        }


    }
}