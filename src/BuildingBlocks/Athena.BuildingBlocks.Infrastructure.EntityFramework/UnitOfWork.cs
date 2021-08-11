using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Application;
using Athena.BuildingBlocks.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Athena.BuildingBlocks.Infrastructure.EntityFramework
{
    public class UnitOfWork<T> : IUnitOfWork, IDisposable
        where T : DbContext
    {
        private readonly DbContext _dbContext;
        private readonly CurrentTransactionProvider _currentTransactionProvider;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(T dbContext, CurrentTransactionProvider currentTransactionProvider)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _currentTransactionProvider = currentTransactionProvider;
        }


        public async Task<Guid> BeginTransaction()
        {
            if (_dbContextTransaction == null)
            {
                this._dbContextTransaction = await _dbContext.Database.BeginTransactionAsync();
                _currentTransactionProvider.SetCurrentTransaction(_dbContextTransaction);
            }
            return _dbContextTransaction.TransactionId;
        }


        public async Task Complete(CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _dbContextTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_dbContextTransaction != null)
                {
                    _dbContextTransaction.Dispose();
                    _dbContextTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Dispose();
                _dbContextTransaction = null;
            }
        }

        private void RollbackTransaction()
        {
            try
            {
                _dbContextTransaction?.Rollback();
            }
            finally
            {
                if (_dbContextTransaction != null)
                {
                    _dbContextTransaction.Dispose();
                    _dbContextTransaction = null;
                }
            }
        }
    }
}
