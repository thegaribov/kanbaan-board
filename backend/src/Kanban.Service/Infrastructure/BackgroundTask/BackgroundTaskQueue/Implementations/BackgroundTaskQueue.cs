using Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Implementations
{
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly ConcurrentQueue<Func<IServiceScopeFactory, CancellationToken, Task>> _items =
            new ConcurrentQueue<Func<IServiceScopeFactory, CancellationToken, Task>>();

        // Holds the current count of tasks in the queue.
        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void EnqueueTask(Func<IServiceScopeFactory, CancellationToken, Task> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _items.Enqueue(task);
            _signal.Release();
        }

        public async Task<Func<IServiceScopeFactory, CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken)
        {
            // Wait for task to become available
            await _signal.WaitAsync(cancellationToken);

            _items.TryDequeue(out var task);
            return task;
        }
    }
}
