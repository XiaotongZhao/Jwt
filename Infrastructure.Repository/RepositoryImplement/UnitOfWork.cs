using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructure.Common.RepositoryTool;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private IDbContextTransaction transaction;
        private EFContext dbContext;
        private bool disposed;
        public UnitOfWork(EFContext efContext)
        {
            dbContext = efContext;
        }
        public void BeginTransaction()
        {
            if (dbContext != null)
                transaction = dbContext.Database.BeginTransaction();
            else
                return;
        }

        public int Commit()
        {
            int changeCount = dbContext.SaveChanges();
            if (changeCount > 0)
                dbContext.Dispose();
            return changeCount;
        }

        public void CommitAsync()
        {
            if (dbContext != null)
                dbContext.SaveChangesAsync();
            else
                return;
        }

        public int CommitTransaction()
        {
            int changeCount = 0;
            if (dbContext != null)
            {
                changeCount = dbContext.SaveChanges();
                transaction.Commit();
                dbContext.Dispose();
            }
            return changeCount;
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                if (disposed)
                    return;
                disposed = true;
                dbContext.Dispose();
            }
        }

        public DbContext Get()
        {
            return dbContext;
        }

        public void RollbackTransaction()
        {
            if (dbContext != null)
            {
                transaction.Rollback();
                dbContext.Dispose();
            }
            else
                return;
        }
    }
}
