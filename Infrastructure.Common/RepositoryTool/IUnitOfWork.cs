using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.RepositoryTool
{
    public interface IUnitOfWork
    {
        DbContext Get();
        int Commit();
        void CommitAsync();
        void BeginTransaction();
        int CommitTransaction();
        void RollbackTransaction();
    }
}
