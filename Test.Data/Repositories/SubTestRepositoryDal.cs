using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Test.Core.Entities;
using Test.Core.Repositories;

namespace Test.Data.Repositories
{
    public class SubTestRepositoryDal : EntityRepository<SubTest>, ISubTestRepositoryDal
    {
        private TestContext testContext { get => _testContext as TestContext; }

        public SubTestRepositoryDal(TestContext testContext) : base(testContext)
        {
            // this is a constructor to provide a communication among entity rep., test rep. and unit of work.
        }

        public SubTest CheckSubTest(int id)
        {
            using (var context = new TestContext())
            {
                var result = context.SubTests.FirstOrDefault();
                return result;
            }
        }

        public async Task<SubTest> GetWithParentClassById(int subtestmodelId)
        {
            //using (var context = new TestContext())       //***-----> this method also can be used instead.***
            //{
            //    var result = await context.SubTestModels.Include(x => x.TestModel).SingleOrDefaultAsync(x => x.TestModelId == subtestmodelId);
            //    return result;
            //}

            return await testContext.SubTests.Include(x => x.UpTest).SingleOrDefaultAsync(x => x.UpTestId == subtestmodelId);

        }

    }
}
