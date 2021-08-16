using Athena.Stocks.Application.Contracts;
using Athena.Stocks.Infrastructure;
using Autofac;

namespace Athena.API.Modules.Stocks
{
    public class StocksAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StocksModule>()
                .As<IStocksModule>()
                .InstancePerLifetimeScope();
        }
    }
}