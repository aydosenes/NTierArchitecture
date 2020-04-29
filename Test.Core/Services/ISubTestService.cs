using System.Threading.Tasks;
using Test.Core.Entities;

namespace Test.Core.Services
{
    public interface ISubTestService : IEntityService<SubTestModel>
    {
        SubTestModel CheckSubTest(int id);
        Task<SubTestModel> GetWithParentClassById(int subtestmodelId);
    }
}
