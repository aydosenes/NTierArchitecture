using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Entities;
using Test.Core.EntityPointer;
using Test.Core.Repositories;
using Test.Core.Services;
using Test.Core.UnitOfWork;

namespace Test.Business.Managers
{
    public class SubTestManager : EntityManager<SubTest>, ISubTestService
    {
        public SubTestManager(IUnitOfWork unitOfWork, IEntityRepository<SubTest> repository)
            : base (unitOfWork, repository)
        {

        }
        public SubTest CheckSubTest(int id)
        {
            return _unitOfWork.SubTest.CheckSubTest(id);
        }

        public async Task<SubTest> GetWithParentClassById(int subtestmodelId)
        {
            return await _unitOfWork.SubTest.GetWithParentClassById(subtestmodelId);
        }
                

    }
}
