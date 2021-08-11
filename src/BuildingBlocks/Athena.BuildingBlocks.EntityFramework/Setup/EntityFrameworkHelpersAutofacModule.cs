using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Athena.BuildingBlocks.EntityFramework.Setup
{
    public class EntityFrameworkHelpersAutofacModule<TDbContext> : Autofac.Module
        where TDbContext : DbContext
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentDbConnectionProvider<TDbContext>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CurrentTransactionProvider>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
