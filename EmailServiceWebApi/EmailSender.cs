﻿using System;
using EmailService.Db.Models;
using EmailServiceWebApi.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using Org.BouncyCastle.Cms;

namespace EmailServiceWebApi
{
    public class EmailSender
    {

        private readonly ILogger<EmailSender> logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            this.logger = logger;
        }

        public void SendEmailMessage(MailsDbItem item)
        {
            var jsonProvider = new JsonProvider("configurationEmailServer");
            var configEmailServer = jsonProvider.Read<ConfigureEmailServer>();
            //
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("EmailServiceWebApi", configEmailServer.EmailFrom));

                //foreach (var recipient in item.Recipients)
                //{
                //    message.To.Add(new MailboxAddress("", recipient));
                //}
                message.To.Add(new MailboxAddress("", item.Recipients));

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
                    logger.LogInformation("Сообщение отправлено успешно!");
                    item.Result = "OK";
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
                item.Result = "Failed";
                item.FailedMessage = e.GetBaseException().Message;
            }
        }
    }
}