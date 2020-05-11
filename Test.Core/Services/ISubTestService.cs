using System.Threading.Tasks;
using Test.Core.Entities;

namespace Test.Core.Services
{
    public interface ISubTestService : IEntityService<SubTest>
    {
        SubTest CheckSubTest(int id);
        Task<SubTest> GetWithParentClassById(int subtestmodelId);
    }
}
