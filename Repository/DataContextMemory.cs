
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Wevo.Repository
{
    public class DataContextMemory : DataContext
    {
       internal DataContextMemory(DbContextOptions options) : base (options)
        {
        }

        public DataContextMemory(DbContextOptions<DataContextMemory> options) : base (options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            .UseInMemoryDatabase("Wevo");


    }
}