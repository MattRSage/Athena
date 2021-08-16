﻿using System.Collections.Specialized;
using Athena.Stocks.Infrastructure.Configuration.Processing.Inbox;
using Athena.Stocks.Infrastructure.Configuration.Processing.InternalCommands;
using Athena.Stocks.Infrastructure.Configuration.Processing.Outbox;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Serilog;

namespace Athena.Stocks.Infrastructure.Configuration.Processing.Quartz
{
    internal static class QuartzStartup
    {
        private static IScheduler _scheduler;

        internal static void Initialize(ILogger logger)
        {
            logger.Information("Quartz starting...");

            var schedulerConfiguration = new NameValueCollection();
            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Stocks");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            LogProvider.SetCurrentLogProvider(new SerilogLogProvider(logger));

            _scheduler.Start().GetAwaiter().GetResult();

            var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();
            var trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();

            _scheduler
                .ScheduleJob(processOutboxJob, trigger)
                .GetAwaiter().GetResult();

            var processInboxJob = JobBuilder.Create<ProcessInboxJob>().Build();
            var processInboxTrigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();

            _scheduler
                .ScheduleJob(processInboxJob, processInboxTrigger)
                .GetAwaiter().GetResult();

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();
            var triggerCommandsProcessing =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();
            _scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

            logger.Information("Quartz started.");
        }

        internal static void StopQuartz()
        {
            _scheduler?.Shutdown();
        }
    }
}