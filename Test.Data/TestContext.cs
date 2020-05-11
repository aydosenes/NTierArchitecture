using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Data.DefaultDataConfig;
using Test.Data.EntityConfiguration;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public DbSet<UpTest> UpTests { get; set; }
        public DbSet<SubTest> SubTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UpTestConfiguration());
            modelBuilder.ApplyConfiguration(new SubTestConfiguration());

            modelBuilder.ApplyConfiguration(new UpTestDefaultData(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new SubTestDefaultData(new int[] { 1, 2, 3 }));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=AYDOS\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True", referencePointer => referencePointer.MigrationsAssembly("Test.Data"));
        }
    }
}
//@"Data Source=AYDOS\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True"