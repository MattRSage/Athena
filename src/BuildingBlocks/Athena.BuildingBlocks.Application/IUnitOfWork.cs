using System;
using System.Threading;
using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Application
{
    public interface IUnitOfWork
    {
        Task<Guid> BeginTransaction();
        Task Complete(CancellationToken cancellationToken = default);
    }
}
