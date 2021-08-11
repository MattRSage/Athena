using Microsoft.EntityFrameworkCore.Storage;

namespace Athena.BuildingBlocks.EntityFramework
{
    public class CurrentTransactionProvider
    {
        private IDbContextTransaction currentTransaction;

        public IDbContextTransaction CurrentTransaction => currentTransaction;

        public void SetCurrentTransaction(IDbContextTransaction transaction)
        {
            currentTransaction = transaction;
        }
    }
}
