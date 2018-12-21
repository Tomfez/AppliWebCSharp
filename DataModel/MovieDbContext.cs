using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class MovieDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }

        public MovieDbContext()
        {

        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=moviedb;uid=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Movie>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                ;
*/        }
    }
}
