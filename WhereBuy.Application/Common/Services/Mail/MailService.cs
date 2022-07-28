using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using WhereBuy.Common.Abstractions;
using WhereBuy.Application.Configuration;

namespace WhereBuy.Application.Common.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly MailConfiguration configuration;

        public MailService(MailConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendCodeAsync(string to, long code)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(configuration.Name, configuration.Mail));
            message.To.Add(new MailboxAddress(null, to));

            message.Subject = "Verify Email Address";

            message.Body = new TextPart("plain")
            {
                Text = $"Your security code - {code}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(configuration.SmtpHost, configuration.SmtpPort, configuration.UseSsl);

                await client.AuthenticateAsync(configuration.Mail, configuration.Password);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
        }
    }
}
