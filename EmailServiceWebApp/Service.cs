using System;
using EmailServiceWebApp.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace EmailServiceWebApp
{
    public class Service
    {
        private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public void SendEmailMessage()
        {
            var jsonProvider = new JsonProvider("configurationEmailServer");
            var configEmailServer = jsonProvider.Read<ConfigureEmailServer>();
            //
            try
            {
                var message = new MimeMessage(); // Класс библиотеки MailKit
                message.From.Add(new MailboxAddress("EmailServiceWebApp", configEmailServer.EmailFrom));  //адрес отправления
                message.To.Add(new MailboxAddress("NoName", configEmailServer.EmailTo)); //адрес назначения
                message.Subject = configEmailServer.Subject;//тема сообщения
                message.Body = new BodyBuilder()
                {
                    HtmlBody = configEmailServer.Body, // тело сообщения
                }.ToMessageBody();
                //message.Body = new TextPart("plain")
                //{
                //    Text = @"Дети хотят стать взрослыми. Взрослые хотят стать детьми. И только подростки уже устали от жизни и хотят сдохнуть"
                //};

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);


                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(configEmailServer.EmailFrom, configEmailServer.Password);

                    client.Send(message);
                    client.Disconnect(true);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}