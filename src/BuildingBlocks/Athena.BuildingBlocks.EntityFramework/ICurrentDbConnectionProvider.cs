using System.Data.Common;

namespace Athena.BuildingBlocks.EntityFramework
{
    public interface ICurrentDbConnectionProvider
    {
        DbConnection DbConnection { get; }
    }
}
