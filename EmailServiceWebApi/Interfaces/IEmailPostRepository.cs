using System.Collections.Generic;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi.Interfaces
{
    public interface IEmailPostRepository
    {
        void Add(EmailPostItem item);
        IEnumerable<EmailPostItem> GetAll();
    }
}