using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Data
{
    public class MailMock : IMail
    {
        List<Mail> mails = new List<Mail>
        {
            new Mail{Id=1, Name="ig1", Email="igprog@yahoo.com1", Phone="0981"},
            new Mail{Id=2, Name="ig2", Email="igprog@yahoo.com2", Phone="0982"},
            new Mail{Id=3, Name="ig3", Email="igprog@yahoo.com3", Phone="0983"}
        };

        public IEnumerable<Mail> GetAllMails()
        {
            return mails;
        }

        public Mail GetMailById(int id)
        {
            return mails.FirstOrDefault(p => p.Id == id);
        }

        public MailData.Response SendMail(Mail msg)
        {
            throw new System.NotImplementedException();
        }
    }
}