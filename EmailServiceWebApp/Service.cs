using System;
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

        public void SendEmailCustom()
        {
            try
            {
                MimeMessage message = new MimeMessage(); // Класс библиотеки MailKit
                message.From.Add(new MailboxAddress("EmailServiceWebApp", "molotovalexmarks@gmail.com")); //адрес отправления
                message.To.Add(new MailboxAddress("", "odisei.arco26@gmail.com")); //адрес назначения
                message.Subject = "thema"; //тема сообщения
                message.Body = new BodyBuilder()
                {
                    HtmlBody = "<div stile =\"color: green;\">Сообщение от EmailServiceWebApp</div>", // тело сообщения
                }.ToMessageBody();
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 578, true); //подключение к сервису gmail, порт, соединение защищено
                    client.Authenticate("molotovalexmarks@gmail.com", "pass"); //аккаунт гугл и пароль
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