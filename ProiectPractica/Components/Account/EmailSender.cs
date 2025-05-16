using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProiectPractica.Entities;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProiectPractica.Components.Account
{
    public class EmailSender : IEmailSender<AppUserEntity>
    {
        private readonly AuthMessageSenderOptions _options;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<EmailSender> logger)
        {
            _options = optionsAccessor.Value;
            _logger = logger;
        }

        public async Task SendConfirmationLinkAsync(AppUserEntity user, string email, string confirmationLink)
        {
            _logger.LogInformation("Attempting to send confirmation email to {Email}", email);
            await Execute(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
        }

        public async Task SendPasswordResetLinkAsync(AppUserEntity user, string email, string resetLink)
        {
            _logger.LogInformation("Attempting to send password reset email to {Email}", email);
            await Execute(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
        }

        public async Task SendPasswordResetCodeAsync(AppUserEntity user, string email, string resetCode)
        {
            _logger.LogInformation("Attempting to send password reset code to {Email}", email);
            await Execute(email, "Password reset code", $"Your password reset code is: {resetCode}");
        }

        private async Task Execute(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new System.Net.NetworkCredential(_options.SmtpUsername, _options.SmtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@proiectpractica.com", "Proiect Practica"),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent successfully to {Email} via Mailtrap", email);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to send email to {Email}. Error: {Error}", email, ex.Message);
                throw;
            }
        }
    }

    public class AuthMessageSenderOptions
    {
        public string? SmtpUsername { get; set; }
        public string? SmtpPassword { get; set; }
    }
}