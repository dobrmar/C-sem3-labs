using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class SQLManager : DbContext
    {

        public DbSet<Composition> CompList { get; set; } = null!;
        public SQLManager()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ListOfCompositions.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Composition>().HasKey(c => new { c.AuthorName, c.Name });
        }

    }
}
