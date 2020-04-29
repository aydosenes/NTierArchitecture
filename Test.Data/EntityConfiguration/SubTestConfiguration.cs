using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Core.Entities;

namespace Test.Data.EntityConfiguration
{
    public class SubTestConfiguration : IEntityTypeConfiguration<SubTestModel>
    {
        public void Configure(EntityTypeBuilder<SubTestModel> builder)
        {
            builder.HasKey(x => x.SubTestModelId);
            builder.Property(x => x.SubTestModelId).UseIdentityColumn();
            builder.Property(x => x.Country).IsRequired().HasMaxLength(20);
            builder.Property(x => x.City).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);
            builder.ToTable("SubTest");
        }
    }
}
