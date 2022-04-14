using System.Collections.Generic;
using api.Models;

namespace api.Data
{
    public interface IMail
    {
        MailData.Response SendMail(Mail x);
        IEnumerable<Mail> GetAllMails();
        Mail GetMailById(int id);


    }
}