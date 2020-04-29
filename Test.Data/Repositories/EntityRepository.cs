using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Core.EntityPointer;
using Test.Core.Repositories;

namespace Test.Data.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>      //, TContext
        where TEntity : class, IEntity, new()
        //where TContext : DbContext, new()
    {
        
        protected readonly DbContext _testContext;
        private readonly DbSet<TEntity> _dbSet;
        public EntityRepository(TestContext testContext)
        {
            _testContext = testContext;                 //reaches to database
            _dbSet = testContext.Set<TEntity>();      //reaches to tables
        }
        public async Task AddAsync(TEntity entity)
        {            
            await _dbSet.AddAsync(entity);

            //using (var context = new TContext())  //---> can be used after adding a TContext parameter to Entity Repository class.
            //{
            //    await context.AddAsync(entity);
            //}
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            //using (var context = new TContext())
            //{
            //    await context.AddRangeAsync(entities);                
            //}
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();

            //using (var context = new TContext())
            //{
            //    return await context.Set<TEntity>().Where(filter).ToListAsync();
            //}
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {

            //using (var context = new TContext())
            //{
                return await Task.Run(() => _dbSet.SingleOrDefaultAsync(filter));
            //}
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            //using (var context = new TContext())
            //{
                return await _dbSet.ToListAsync();
            //}
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            //using (var context = new TContext())
            //{
                return await _dbSet.FindAsync(id);
            //}
        }

        public async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            //using (var context = new TContext())
            //{
            return filter == null
            ? await Task.Run(() => _dbSet.ToListAsync())
            : await Task.Run(() => _dbSet.Where(filter).ToListAsync());
            //}
        }

        public void Remove(TEntity entity)
        {
            //using (var context = new TContext())
            //{
                _dbSet.Remove(entity);
            //}
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            //using (var context = new TContext())
            //{
                _dbSet.RemoveRange(entities);
            //}
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            //using (var context = new TContext())
            //{
                return await _dbSet.SingleOrDefaultAsync(filter);
            //}
        }

        public TEntity Update(TEntity entity)
        {
            //using (var context = new TContext())
            //{
            _testContext.Entry(entity).State = EntityState.Modified;
            return entity;
            //}
        }  

    }
}
