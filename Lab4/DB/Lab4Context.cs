using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DB
{
    public sealed class Lab4Context : DbContext
    {
        public DbSet<Composition> CompList { get; set; }

        public Lab4Context(DbContextOptions<Lab4Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Composition>().HasKey(c => new { c.AuthorName, c.Name });
        }
    }
}