using System;
using Athena.BuildingBlocks.EntityFramework.Setup;
using Athena.BuildingBlocks.Infrastructure.EntityFramework;
using Athena.BuildingBlocks.Infrastructure.EntityFramework.Setup;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Athena.Stocks.Infrastructure.Setup
{
    public class InfrastructureAutofacModule : Autofac.Module
    {
        private readonly string databaseConnectionString;

        public InfrastructureAutofacModule(string databaseConnectionString)
        {
            this.databaseConnectionString = databaseConnectionString ?? throw new ArgumentNullException(nameof(databaseConnectionString));
        }

        /// <summary>
        /// The Load.
        /// </summary>
        /// <param name="builder">The builder <see cref="ContainerBuilder"/>.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureEntityFrameworkAutofacModule<StocksDbContext>(databaseConnectionString));

            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<StocksDbContext>()
                                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                opt.UseSqlServer(databaseConnectionString);

                return new StocksDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterModule(new EntityFrameworkHelpersAutofacModule<StocksDbContext>());

            builder.RegisterModule(new InfrastructureEntityFrameworkAutofacModule<StocksDbContext>(databaseConnectionString));

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}