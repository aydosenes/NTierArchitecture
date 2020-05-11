using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Test.Core.Repositories;

namespace Test.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUpTestRepositoryDal UpTest { get; }
        ISubTestRepositoryDal SubTest { get; }

        Task CommitAsync();

        void Commit();
    }
}
