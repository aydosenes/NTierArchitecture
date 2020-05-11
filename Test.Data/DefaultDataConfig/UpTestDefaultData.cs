using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Test.Core.Entities;

namespace Test.Data.DefaultDataConfig
{
    public class UpTestDefaultData : IEntityTypeConfiguration<UpTest>
    {
        private readonly int[]_ids;

        public UpTestDefaultData(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<UpTest> builder)
        {
            builder.HasData(
                new UpTest
                {
                    Id = _ids[0],
                    IdentityNo = 12345678910,
                    Name = "Name1",
                    SurName = "Surname1",
                    BirthDate = new DateTime(1995, 12, 28)
                },
                new UpTest
                {
                    Id = _ids[1],
                    IdentityNo = 12345678912,
                    Name = "Name2",
                    SurName = "Surname2",
                    BirthDate = new DateTime(1995, 12, 29)
                },
                new UpTest
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
