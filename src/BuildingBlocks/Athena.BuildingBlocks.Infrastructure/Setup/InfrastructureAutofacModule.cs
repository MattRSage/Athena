using Autofac;

namespace Athena.BuildingBlocks.Infrastructure.Setup
{
    public class InfrastructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>().AsImplementedInterfaces().InstancePerDependency();

            base.Load(builder);
        }
    }
}
