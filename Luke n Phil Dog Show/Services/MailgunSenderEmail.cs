using Luke_n_Phil_Dog_Show.Helpers;
using Luke_n_Phil_Dog_Show.Interfaces;
using FluentEmail.Core;
using FluentEmail.Mailgun;
using Microsoft.Extensions.Options;

namespace Luke_n_Phil_Dog_Show.Services
{
    public class MailgunSenderEmail : IMailgunSenderEmail
    {
        private readonly ILogger _logger;
        public AuthMessageSenderOptions Options { get; set; }

        public MailgunSenderEmail(IOptions<AuthMessageSenderOptions> options, ILogger<MailgunSenderEmail> logger)
        {
            Options = options.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.DomainName))
            {
                throw new Exception("Null MailgunDomain");
            }else if (string.IsNullOrEmpty(Options.ApiKey))
            {
                throw new Exception("Null MailgunKey");
            }
            await Execute(Options.DomainName, Options.ApiKey, subject, message, toEmail);
        }

        private async Task Execute(string domainName, string apiKey, string subject, string message, string toEmail)
        {
            var client = new MailgunSender(domainName, apiKey);
            var msg = Email
                .From($"mailgun@{domainName}")
                .To(toEmail)
                .Subject(subject)
                .Body(message, isHtml: true);

            var response = await client.SendAsync(msg);
            _logger.LogInformation(response.Successful
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }


    }
}
