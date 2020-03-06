using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Common.RepositoryTool;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private IUnitOfWork unitOfWork { get; set; }
        private readonly DbSet<TEntity> dbset;
        private DbContext efContext;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            efContext = this.unitOfWork.Get();
            dbset = efContext.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
            dbset.Add(entity);
            return unitOfWork.Commit();
        }

        public int AddAll(IEnumerable<TEntity> entities)
        {
            dbset.AddRange(entities);
            return unitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            dbset.Remove(entity);
            return unitOfWork.Commit();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public TEntity GetById(TKey id)
        {
            return dbset.Find(id);
        }

        public int Update(TEntity entity)
        {
            dbset.Update(entity);
            return unitOfWork.Commit();
        }
    }
}
