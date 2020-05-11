using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Entities;
using Test.Core.Repositories;

namespace Test.Data.Repositories
{
    public class UpTestRepositoryDal : EntityRepository<UpTest>, IUpTestRepositoryDal
    {
        private TestContext testContext { get => _testContext as TestContext; }
        public UpTestRepositoryDal(TestContext testContext) :base(testContext)
        {
            // this is a constructor to provide a communication among entity rep., test rep. and unit of work.
        }

        public UpTest CheckTest(int idno)
        {
            using (var context = new TestContext())
            {
                var result = context.UpTests.FirstOrDefault();
                return result;
            }
        }

        public async Task<UpTest> GetWithSubClassById(int testId)
        {
            //using (var context = new TestContext())    //***-----> this method also can be used instead.***
            //{
            //    var result = await context.TestModels.Include(x => x.SubTestModels).SingleOrDefaultAsync(x => x.Id == testId);
            //    return result;
            //}

            return await testContext.UpTests.Include(x=>x.SubTest).SingleOrDefaultAsync(x => x.Id == testId);
        }
    }
}
