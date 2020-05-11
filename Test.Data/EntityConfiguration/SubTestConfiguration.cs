using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Core.Entities;

namespace Test.Data.EntityConfiguration
{
    public class SubTestConfiguration : IEntityTypeConfiguration<SubTest>
    {
        public void Configure(EntityTypeBuilder<SubTest> builder)
        {
            builder.HasKey(x => x.SubTestId);
            builder.Property(x => x.SubTestId).UseIdentityColumn();
            builder.Property(x => x.Country).IsRequired().HasMaxLength(20);
            builder.Property(x => x.City).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);
            builder.ToTable("SubTest");
        }
    }
}
