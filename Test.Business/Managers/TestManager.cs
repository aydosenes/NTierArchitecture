using System.Threading.Tasks;
using Test.Core.Entities;
using Test.Core.Repositories;
using Test.Core.Services;
using Test.Core.UnitOfWork;


namespace Test.Business.Managers
{
    public class TestManager : EntityManager<TestModel>, ITestService
    {
        public TestManager(IUnitOfWork unitOfWork, IEntityRepository<TestModel> repository)
            : base(unitOfWork, repository)
        {

        }
        public TestModel CheckTest(int id)
        {
            return _unitOfWork.Test.CheckTest(id);
        }

        public async Task<TestModel> GetWithSubClassById(int testId)
        {
            return await _unitOfWork.Test.GetWithSubClassById(testId);
        }
    }
}
