using System;
using Athena.BuildingBlocks.Infrastructure;
using Athena.Stocks.Infrastructure.Configuration.DataAccess;
using Athena.Stocks.Infrastructure.Configuration.Logging;
using Athena.Stocks.Infrastructure.Configuration.Mediation;
using Athena.Stocks.Infrastructure.Configuration.Processing;
using Athena.Stocks.Infrastructure.Configuration.Processing.Outbox;
using Athena.Stocks.Infrastructure.Configuration.Processing.Quartz;
using Autofac;
using Serilog;

namespace Athena.Stocks.Infrastructure.Configuration
{
    public class StocksStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "Stocks");

            ConfigureCompositionRoot(
                connectionString,
                moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Stocks")));

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());

            _container = containerBuilder.Build();

            StocksCompositionRoot.SetContainer(_container);
        }
    }
}