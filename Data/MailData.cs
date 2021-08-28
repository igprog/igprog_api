using System;
using System.Net;
using System.Net.Mail;
using api.Models;

namespace api.Data
{
    public class MailData : IMail
    {
        public Mail SendMail(Mail x)
        {
            string body = $@"<div>Ime: {x.Name}</div>
            <div>Email: <a href=""mailto:{x.Email}?subject=Odgovor na upit"">{x.Email}</a></div>
            <div>Telefon: <a href=""tel:{x.Phone}"">{x.Phone}</a></div>
            <div>Poruka: {x.Msg}</div>";
            x.Resp = SendMail(x.SendTo, "Novi upit", body);
            return x;
        }

        private Response SendMail(string sendTo, string subject, string body)
        {
            try
            {
                string myEmail = "info@igprog.hr";
                string myEmailName = "IG PROG";
                string myServerHost = "mail.igprog.hr";
                int myServerPort = 25;
                string myPassword = "Ii123456$";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(myEmail, myEmailName);
                mail.To.Add(string.IsNullOrWhiteSpace(sendTo) ? myEmail : sendTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(myServerHost, myServerPort);
                NetworkCredential Credentials = new NetworkCredential(myEmail, myPassword);
                smtp.Credentials = Credentials;
                smtp.Send(mail);
                Response r = new Response();
                r.IsSent = true;
                r.Msg = "Vaša poruka je uspješno poslana";
                r.Msg1 = "Odgovorit ćemo Vam u roku od 24h";
                return r;
            }
            catch (Exception e)
            {
                Response r = new Response();
                r.IsSent = false;
                r.Msg = e.Message;
                r.Msg1 = e.StackTrace;
                return r;
            }
        }
    }
}