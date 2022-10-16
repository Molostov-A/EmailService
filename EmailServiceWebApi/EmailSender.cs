using System;
using System.Threading.Tasks;
using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailServiceWebApi
{
    public class EmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly ConfigureEmailServer _configureEmailServer;

        public EmailSender(ILogger<EmailSender> logger, IOptions<ConfigureEmailServer> options)
        {
            _logger = logger;
            _configureEmailServer = options.Value;
        }

        /// <summary>
        /// Send email messages
        /// </summary>
        /// <param name="item">The data packet required to send messages</param>
        public async Task SendEmailMessageAsync(MailsItem item)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_configureEmailServer.TitleMail, _configureEmailServer.EmailFrom));

                foreach (var recipient in item.Recipients)
                {
                    message.To.Add(new MailboxAddress("", recipient.Email));
                }

                message.Subject = item.Subject;
                message.Body = new BodyBuilder()
                {
                    HtmlBody = item.Body,

                }.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_configureEmailServer.Host, _configureEmailServer.Port);

                    if(_configureEmailServer.RemoveAuthenticationMechanism)
                        client.AuthenticationMechanisms.Remove(_configureEmailServer.TypeTokenAuthenticationMechanism);

                    await client.AuthenticateAsync(_configureEmailServer.EmailFrom, _configureEmailServer.Password);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    _logger.LogInformation("Message sent successfully!");
                    item.Result = "OK";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
                item.Result = "Failed";
                item.FailedMessage = e.GetBaseException().Message;
            }
        }
    }
}