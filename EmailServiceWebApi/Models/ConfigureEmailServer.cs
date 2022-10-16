namespace EmailServiceWebApi.Models
{
    /// <summary>
    /// SMTP server configuration
    /// </summary>
    public class ConfigureEmailServer
    {
        /// <summary>
        /// SMTP server email address
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// Password for access to the SMTP server
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Sender name
        /// </summary>
        public string SenderNameMail { get; set; }

        /// <summary>
        /// Name of the host through which the email is sent
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The port number through which the email is sent
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Choosing whether to remove the authentication mechanism
        /// </summary>
        public bool RemoveAuthenticationMechanism { get; set; }

        /// <summary>
        /// Type mechanism token authentication 
        /// </summary>
        public string TypeTokenAuthenticationMechanism { get; set; }

    }
}