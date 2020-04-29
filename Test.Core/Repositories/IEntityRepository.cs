using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Core.EntityPointer;

namespace Test.Core.Repositories
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        
        Task<T> GetByIdAsync(int id);    //gets from database by id.
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter); //gets from database by anything.
        Task<IEnumerable<T>> GetAllAsync();
        Task<IList<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> filter); //gets objects according to parameter.

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities); //adds lots of record.
        T Update(T entity);
        //Task Update(T entity);
        void Remove(T entity);
        //Task Delete(T entity);
        void RemoveRange(IEnumerable<T> entities);


        
    }
}
