using System;
using System.Linq;
using System.Linq.Expressions;
using Fc.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fc.Infraestructure.Implementations
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly UnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.DbContext.Dispose();
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.DbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.DbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _unitOfWork.DbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}