using System.Threading.Tasks;
using Test.Core.Entities;


namespace Test.Core.Services
{
    public interface ITestService : IEntityService<TestModel>
    {
        TestModel CheckTest(int id);
        Task<TestModel> GetWithSubClassById(int testId);
    }
}
