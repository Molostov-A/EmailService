using System.Collections.Generic;

namespace EmailServiceWebApi.Models
{
    public interface IEmailPostRepository
    {
        void Add(EmailPostItem item);
        IEnumerable<EmailPostItem> GetAll();
    }
}