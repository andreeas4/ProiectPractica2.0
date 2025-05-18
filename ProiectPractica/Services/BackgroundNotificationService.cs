using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ProiectPractica.Data;
using ProiectPractica.Entities;
using ProiectPractica.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectPractica.Services
{
    public class BackgroundNotificationService : BackgroundService
    {
        private readonly ILogger<BackgroundNotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IServiceScopeFactory _scopeFactory;

        public BackgroundNotificationService(ILogger<BackgroundNotificationService> logger,
            IHubContext<NotificationHub> hubContext,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _hubContext = hubContext;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Checking for recurring notifications at {Time}", DateTime.Now);
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                        await CheckAndSendNotificationsAsync(dbContext, notificationService);
                    }
                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // Check daily
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in BackgroundNotificationService");
                }
            }
        }

        private async Task CheckAndSendNotificationsAsync(ApplicationDbContext dbContext, INotificationService notificationService)
        {
            var today = DateTime.Now;
            var tasks = await dbContext.Taskuri
                .Include(t => t.Proiect)
                .Where(t => t.EsteNotificare)
                .ToListAsync();

            foreach (var task in tasks)
            {
                if (ShouldSendNotification(task, today))
                {
                    _logger.LogInformation("Sending recurring notification for task {TaskId}", task.Id);
                    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == task.ResponsabilId);
                    if (user != null)
                    {
                        await notificationService.SendTaskNotificationAsync(task, user);
                        // Broadcast UI notification to all connected clients
                        await _hubContext.Clients.All.SendAsync("ReceiveNotification",
                            $"Reminder: Task '{task.Descriere}' for project {task.Proiect?.NumeClient} is ongoing.");
                    }
                }
            }
        }

        private bool ShouldSendNotification(TaskProiectEntity task, DateTime today)
        {
            var startDate = task.DataStart;
            bool shouldSend = today.Day == startDate.Day &&
                             today >= startDate.AddMonths(1) &&
                             today.Year == startDate.Year + (today.Month - startDate.Month + 12) / 12;
            return shouldSend;
        }
    }

    // Notification Hub remains unchanged
    public class NotificationHub : Hub
    {
    }
}