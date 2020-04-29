using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Test.Core.Entities;

namespace Test.Data.DefaultDataConfig
{
    public class TestDefaultData : IEntityTypeConfiguration<TestModel>
    {
        private readonly int[]_ids;

        public TestDefaultData(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<TestModel> builder)
        {
            builder.HasData(
                new TestModel
                {
                    Id = _ids[0],
                    IdentityNo = 12345678910,
                    Name = "Name1",
                    SurName = "Surname1",
                    BirthDate = new DateTime(1995, 12, 28)
                },
                new TestModel
                {
                    Id = _ids[1],
                    IdentityNo = 12345678912,
                    Name = "Name2",
                    SurName = "Surname2",
                    BirthDate = new DateTime(1995, 12, 29)
                },
                new TestModel
                {
                    Id = _ids[2],
                    IdentityNo = 12345678914,
                    Name = "Name3",
                    SurName = "Surname3",
                    BirthDate = new DateTime(1995, 12, 30)
                }
                );
        }
    }
}
