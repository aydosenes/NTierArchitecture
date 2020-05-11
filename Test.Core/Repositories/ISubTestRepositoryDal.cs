using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Entities;

namespace Test.Core.Repositories
{
    public interface ISubTestRepositoryDal : IEntityRepository<SubTest>
    {
        SubTest CheckSubTest(int id);
        Task<SubTest> GetWithParentClassById(int subtestmodelId);
    }
}
