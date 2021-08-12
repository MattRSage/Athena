using System;
using System.Linq;
using System.Reflection;
using Athena.BuildingBlocks.Application.Behaviors;
using Athena.BuildingBlocks.Application.Setup;
using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Athena.Stocks.Application.Setup
{
    public class ApplicationAutofacModule : Autofac.Module
    {
        private readonly string _connectionString;

        public ApplicationAutofacModule(string connectionString)
        {
            _connectionString = connectionString ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule(new ApplicationBaseAutofacModule());

            builder.RegisterMediatR(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(UnitOfWorkTransactionBehavior<,>)).As(typeof(IPipelineBehavior<,>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(DomainEventDispatchingBehvaior<,>)).As(typeof(IPipelineBehavior<,>)).InstancePerDependency();
            
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("IntegrationEventHandler"))
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}