// using System.Collections.Generic;
// using api.Models;
// using System.Linq;

// namespace api.Data
// {
//     public class SqlMail : IMail
//     {
//         private readonly MailContext _context;

//         public SqlMail(MailContext context)
//         {
//             _context = context;
//         }
//         public IEnumerable<Mail> GetAllMails()
//         {
//            return _context.Mails.ToList(); 
//         }

//         public Mail GetMailById(int id)
//         {
//             return _context.Mails.FirstOrDefault(p => p.Id == id);
//         }

//         // public MailData.Response SendMail(Mail msg)
//         // {
//         //     throw new System.NotImplementedException();
//         // }
//     }
// }