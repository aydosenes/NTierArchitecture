using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Core.Entities;

namespace Test.Data.DefaultDataConfig
{
    public class SubTestDefaultData : IEntityTypeConfiguration<SubTestModel>
    {
        private readonly int[] _ids;
        public SubTestDefaultData(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<SubTestModel> builder)
        {
            builder.HasData(
                new SubTestModel
                {
                    SubTestModelId = 1,
                    Country = "Turkey",
                    City = "Ankara",
                    Phone = 5321234567,
                    TestModelId = _ids[0]
                },
                new SubTestModel
                {
                    SubTestModelId = 2,
                    Country = "Turkey",
                    City = "Istanbul",
                    Phone = 5321234567,
                    TestModelId = _ids[1]
                },
                new SubTestModel
                {
                    SubTestModelId = 3,
                    Country = "Turkey",
                    City = "Izmir",
                    Phone = 5321234567,
                    TestModelId = _ids[2]
                }
                );
        }
    }
}
