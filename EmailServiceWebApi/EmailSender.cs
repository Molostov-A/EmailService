﻿using System;
using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace EmailServiceWebApi
{
    public class EmailSender
    {

        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Send email messages
        /// </summary>
        /// <param name="item">The data packet required to send messages</param>
        public void SendEmailMessage(MailsItem item)
        {
            var jsonProvider = new JsonProvider("configurationEmailServer");
            var configEmailServer = jsonProvider.Read<ConfigureEmailServer>();
            //
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("EmailServiceWebApi", configEmailServer.EmailFrom));

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
                    client.Connect("smtp.gmail.com", 587);

                    // since we don't have an OAuth2 token, disable the OAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // only needed if the SMTP server requires authentication
                    client.Authenticate(configEmailServer.EmailFrom, configEmailServer.Password);

                    client.Send(message);
                    client.Disconnect(true);
                    _logger.LogInformation("Сообщение отправлено успешно!");
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