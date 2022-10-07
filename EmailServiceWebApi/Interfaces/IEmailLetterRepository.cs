using System.Collections.Generic;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi.Interfaces
{
    public interface IEmailLetterRepository
    {
        void Add(EmailLetterItem item);
        IEnumerable<EmailLetterItem> GetAll();
    }
}