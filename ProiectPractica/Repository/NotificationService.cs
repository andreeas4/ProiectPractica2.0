using Microsoft.JSInterop;
using ProiectPractica.Entities;
using ProiectPractica.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
namespace ProiectPractica.Repository
{
    public class NotificationService : INotificationService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IConfiguration _configuration;

        public NotificationService(IJSRuntime jsRuntime, IConfiguration configuration)
        {
            _jsRuntime = jsRuntime;
            _configuration = configuration;
        }

        public async Task SendTaskNotificationAsync(TaskProiectEntity task, AppUserEntity recipient)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Project Management System", _configuration["Smtp:FromEmail"] ?? "from@example.com"));
                message.To.Add(new MailboxAddress(recipient.UserName, recipient.Email));
                message.Subject = $"New Task Assigned: {task.Descriere}";

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = $"You have been assigned a new task:\n\n" +
                               $"Description: {task.Descriere}\n" +
                               $"Project Code: {task.Cod}\n" +
                               $"Start Date: {task.DataStart:yyyy-MM-dd}\n" +
                               $"Deadline: {task.Deadline:yyyy-MM-dd}\n" +
                               $"Status: {task.Status}"
                };
                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(
                    _configuration["Smtp:Host"] ?? "sandbox.smtp.mailtrap.io",
                    int.Parse(_configuration["Smtp:Port"] ?? "2525"),
                    SecureSocketOptions.StartTls
                );

                await client.AuthenticateAsync(
                    _configuration["Smtp:Username"] ?? "37edf2953bd87d",
                    _configuration["Smtp:Password"] ?? "****25a5"
                );

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log the error (use your logging mechanism)
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }

        public async Task ShowUINotificationAsync(string message, string userId)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("showToast", message);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Failed to show UI notification: {ex.Message}");
            }
        }
    }
}
