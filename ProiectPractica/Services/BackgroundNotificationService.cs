using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProiectPractica.Data;
using ProiectPractica.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProiectPractica.Services
{
    public class BackgroundNotificationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<BackgroundNotificationService> _logger;
        public BackgroundNotificationService(IServiceProvider serviceProvider, ILogger<BackgroundNotificationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CheckAndSendNotificationsAsync();
                    // Wait until the next day (check at midnight)
                    var now = DateTime.Now;
                    var nextRun = now.Date.AddDays(1);
                    var delay = nextRun - now;
                    await Task.Delay(delay, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in BackgroundNotificationService");
                }
            }
        }

        private async Task CheckAndSendNotificationsAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

            var today = DateTime.Today;
            var tasks = await dbContext.Taskuri
                .Include(t => t.Responsabil)
                .Include(t => t.Proiect)
                .Where(t => t.EsteNotificare)
                .ToListAsync();

            foreach (var task in tasks)
            {
                if (ShouldSendNotification(task, today))
                {
                    _logger.LogInformation("Sending recurring notification for task {TaskId} to user {UserId}", task.Id, task.ResponsabilId);
                    await notificationService.SendTaskNotificationAsync(task, task.Responsabil);
                    await notificationService.ShowUINotificationAsync(
                        $"Reminder: Task '{task.Descriere}' for project {task.Proiect.NumeClient} is ongoing.",
                        task.ResponsabilId);
                }
            }
        }

        private bool ShouldSendNotification(TaskProiectEntity task, DateTime today)
        {
            var startDate = task.DataStart;
            // Check if today is the same day of the month as DataStart, one or more months later
            return today.Day == startDate.Day &&
                   today >= startDate.AddMonths(1) &&
                   today.Year == startDate.Year + (today.Month - startDate.Month + 12) / 12;
        }
    }
}



