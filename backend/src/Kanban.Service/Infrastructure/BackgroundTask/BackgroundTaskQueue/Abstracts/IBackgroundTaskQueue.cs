using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Abstracts
{
    public interface IBackgroundTaskQueue
    {
        // Enqueues the given task.
        void EnqueueTask(Func<IServiceScopeFactory, CancellationToken, Task> task);

        // Dequeues and returns one task. This method blocks until a task becomes available.
        Task<Func<IServiceScopeFactory, CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}
