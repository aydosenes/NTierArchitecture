using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Entities;

namespace Test.Core.Repositories
{
    public interface IUpTestRepositoryDal : IEntityRepository<UpTest>
    {
        UpTest CheckTest(int id);
        Task<UpTest> GetWithSubClassById(int testId);
    }
}
