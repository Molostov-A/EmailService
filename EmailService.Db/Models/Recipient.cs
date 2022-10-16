using System;

namespace EmailService.Db.Models
{
    /// <summary>
    /// Recipient configuration model
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Id recipient
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Reference to the request in which the recipient is located
        /// </summary>
        public MailsItem MailsItem { get; set; }

        /// <summary>
        /// Email recipient
        /// </summary>
        public string Email { get; set; }
    }
}