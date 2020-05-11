using System.Threading.Tasks;
using Test.Core.Entities;


namespace Test.Core.Services
{
    public interface IUpTestService : IEntityService<UpTest>
    {
        UpTest CheckTest(int id);
        Task<UpTest> GetWithSubClassById(int testId);
    }
}
