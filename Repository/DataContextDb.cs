
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Wevo.Repository
{
    public class DataContextDb : DataContext
    {
        private readonly IConfiguration _config;
        internal DataContextDb(DbContextOptions options, IConfiguration config) : base (options)
        {
            _config = config;
        }

        public DataContextDb(DbContextOptions<DataContextDb> options, IConfiguration config) : base (options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            .UseSqlite(_config.GetConnectionString("DefaultConnection"));


    }
}