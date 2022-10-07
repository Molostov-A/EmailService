namespace EmailServiceWebApi.Models
{
    public class EmailPost
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] Recipients { get; set; }

    }
}