﻿using Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Implementations
{
    public class BackgroundQueueHostedService : BackgroundService
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<BackgroundQueueHostedService> _logger;

        public BackgroundQueueHostedService(IBackgroundTaskQueue taskQueue, IServiceScopeFactory serviceScopeFactory, ILogger<BackgroundQueueHostedService> logger)
        {
            _taskQueue = taskQueue ?? throw new ArgumentNullException(nameof(taskQueue));
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Dequeue and execute tasks until the application is stopped
            while (!stoppingToken.IsCancellationRequested)
            {
                // Get next task
                // This blocks until a task becomes available
                var task = await _taskQueue.DequeueAsync(stoppingToken);

                try
                {
                    // Run task
                    await task(_serviceScopeFactory, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occured during execution of a background task");
                }
            }
        }
    }
}
