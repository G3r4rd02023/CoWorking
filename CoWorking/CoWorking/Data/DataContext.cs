using CoWorking.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoWorking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Place>().HasIndex(c => c.Name).IsUnique();
           
        }
    }
}
