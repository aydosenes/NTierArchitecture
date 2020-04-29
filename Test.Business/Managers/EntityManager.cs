using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Core.EntityPointer;
using Test.Core.Repositories;
using Test.Core.Services;
using Test.Core.UnitOfWork;

namespace Test.Business.Managers
{
    public class EntityManager<TEntity> : IEntityService<TEntity>
        where TEntity : class, IEntity, new()
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<TEntity> _repository;

        public EntityManager(IUnitOfWork unitOfWork, IEntityRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.Get(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _repository.GetList();
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.SingleOrDefaultAsync(filter);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity process = _repository.Update(entity);
            _unitOfWork.CommitAsync();
            return process;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.Where(filter);
        }
    }
}
