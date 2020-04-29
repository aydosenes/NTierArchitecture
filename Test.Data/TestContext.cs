using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Data.DefaultDataConfig;
using Test.Data.EntityConfiguration;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<SubTestModel> SubTestModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new SubTestConfiguration());

            modelBuilder.ApplyConfiguration(new TestDefaultData(new int[] { 1, 2, 3 }));
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