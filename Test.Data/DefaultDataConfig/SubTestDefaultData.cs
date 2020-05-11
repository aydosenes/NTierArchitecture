using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Core.Entities;

namespace Test.Data.DefaultDataConfig
{
    public class SubTestDefaultData : IEntityTypeConfiguration<SubTest>
    {
        private readonly int[] _ids;
        public SubTestDefaultData(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<SubTest> builder)
        {
            builder.HasData(
                new SubTest
                {
                    SubTestId = 1,
                    Country = "Turkey",
                    City = "Ankara",
                    Phone = 5321234567,
                    UpTestId = _ids[0]
                },
                new SubTest
                {
                    SubTestId = 2,
                    Country = "Turkey",
                    City = "Istanbul",
                    Phone = 5321234567,
                    UpTestId = _ids[1]
                },
                new SubTest
                {
                    SubTestId = 3,
                    Country = "Turkey",
                    City = "Izmir",
                    Phone = 5321234567,
                    UpTestId = _ids[2]
                }
                );
        }
    }
}
