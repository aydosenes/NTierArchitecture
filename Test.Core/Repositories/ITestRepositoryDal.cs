using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Entities;

namespace Test.Core.Repositories
{
    public interface ITestRepositoryDal : IEntityRepository<TestModel>
    {
        TestModel CheckTest(int id);
        Task<TestModel> GetWithSubClassById(int testId);
    }
}
