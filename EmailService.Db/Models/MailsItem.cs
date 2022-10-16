using System;
using System.Collections.Generic;

namespace EmailService.Db.Models
{
    /// <summary>
    /// The request saving configuration model
    /// </summary>
    public class MailsItem
    {
        /// <summary>
        /// Request Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Request date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The header of the email to be sent
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The content of the email to be sent
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Email recipients
        /// </summary>
        public List<Recipient> Recipients { get; set; }

        /// <summary>
        /// Sending result (values "OK" "Failed")
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Error message (blank or contains a notification sending error)
        /// </summary>
        public string FailedMessage { get; set; }

    }
}