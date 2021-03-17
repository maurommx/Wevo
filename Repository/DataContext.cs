
using Wevo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Wevo.Repository
{
    public class DataContext : DbContext
    {
        protected DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected DataContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        
        
    }
}