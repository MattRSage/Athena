using System;
using System.Diagnostics.CodeAnalysis;
using Athena.BuildingBlocks.Infrastructure.Setup;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Athena.BuildingBlocks.Infrastructure.EntityFramework.Setup
{

    [ExcludeFromCodeCoverage]
    public class InfrastructureEntityFrameworkAutofacModule<TDbContext> : Autofac.Module
        where TDbContext : DbContext
    {
        private readonly string databaseConnectionString;

        public InfrastructureEntityFrameworkAutofacModule(string databaseConnectionString)
        {
            this.databaseConnectionString = databaseConnectionString ?? throw new ArgumentNullException(nameof(databaseConnectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureAutofacModule());

            builder.RegisterType<DomainEventsAccessor<TDbContext>>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<UnitOfWork<TDbContext>>().AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }

}
