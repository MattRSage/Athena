using System.Reflection;
using Athena.Stocks.Application.Configuration.Commands;

namespace Athena.Stocks.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}