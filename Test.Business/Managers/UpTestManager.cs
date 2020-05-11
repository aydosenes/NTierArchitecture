using System.Threading.Tasks;
using Test.Core.Entities;
using Test.Core.Repositories;
using Test.Core.Services;
using Test.Core.UnitOfWork;


namespace Test.Business.Managers
{
    public class UpTestManager : EntityManager<UpTest>, IUpTestService
    {
        public UpTestManager(IUnitOfWork unitOfWork, IEntityRepository<UpTest> repository)
            : base(unitOfWork, repository)
        {

        }
        public UpTest CheckTest(int id)
        {
            return _unitOfWork.UpTest.CheckTest(id);
        }

        public async Task<UpTest> GetWithSubClassById(int testId)
        {
            return await _unitOfWork.UpTest.GetWithSubClassById(testId);
        }
    }
}
