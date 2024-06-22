using Film.Models;
using Microsoft.EntityFrameworkCore;

namespace Film.Data.Concrete
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Category> Category => Set<Category>();

        public DbSet<Movie> Movies => Set<Movie>();
    }
}