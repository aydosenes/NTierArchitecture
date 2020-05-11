using System;
using System.Threading.Tasks;
using Test.Core.Repositories;
using Test.Core.UnitOfWork;
using Test.Data.Repositories;

namespace Test.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private UpTestRepositoryDal _uptestRepository;
        private SubTestRepositoryDal _subTestRepository;
        private readonly TestContext _testContext;

        public IUpTestRepositoryDal UpTest => _uptestRepository = _uptestRepository ?? new UpTestRepositoryDal(_testContext);
        public ISubTestRepositoryDal SubTest => _subTestRepository = _subTestRepository ?? new SubTestRepositoryDal(_testContext);

        public UnitOfWork(TestContext testContext)
        {
            _testContext = testContext;
        }

        public void Commit()
        {
            using (var context = new TestContext())
            {
                context.SaveChanges();
            }

        }

        public async Task CommitAsync()
        {
            using (var context = new TestContext())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
