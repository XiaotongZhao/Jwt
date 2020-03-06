using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.Common.RepositoryTool
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        int Add(TEntity entity);
        int AddAll(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity GetById(TKey id);
        IQueryable<TEntity> GetAll();
    }
}
