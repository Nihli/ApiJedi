using Microsoft.EntityFrameworkCore;
using API_StarWars.Models;

namespace API_StarWars.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Jedi> JediSet { get; set; }
    }
}