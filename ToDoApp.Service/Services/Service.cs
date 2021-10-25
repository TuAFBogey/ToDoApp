using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;
using ToDoApp.Core.UnitOfWork;

namespace ToDoApp.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
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

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetCompletedAsync()
        {
            return (IEnumerable<TEntity>)await _unitOfWork.ToDos.Where(x => x.IsComplete == true);
        }

        public async Task<IEnumerable<TEntity>> GetNotCompletedAsync()
        {
            return (IEnumerable<TEntity>)await _unitOfWork.ToDos.Where(x => x.IsComplete == false);
        }

        public async Task<IEnumerable<TEntity>> GetByDailyAsync()
        {
            return (IEnumerable<TEntity>)await _unitOfWork.ToDos.Where(x => x.Period == Period.Daily);
        }

        public async Task<IEnumerable<TEntity>> GetByWeeklyAsync()
        {
            return (IEnumerable<TEntity>)await _unitOfWork.ToDos.Where(x => x.Period == Period.Weekly);
        }

        public async Task<IEnumerable<TEntity>> GetByMonthlyAsync()
        {
            return (IEnumerable<TEntity>)await _unitOfWork.ToDos.Where(x => x.Period == Period.Monthly);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }
        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }
    }
}
