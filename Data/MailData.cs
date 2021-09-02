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

            MailSettings mailSetting = GetMailSettings(x.Owner);
            x.Resp = SendMail(x.SendTo, "Novi upit", body, mailSetting);
            return x;
        }

        private MailSettings GetMailSettings(string owner)
        {
            MailSettings x = new MailSettings();
            switch (owner)
            {
                case "igprog":
                    x.Email = "info@igprog.hr";
                    x.Password = "Ii123456$";
                    x.EmailName = "IG PROG";
                    x.ServerHost = "mail.igprog.hr";
                    x.ServerPort = 25;
                    break;
                case "elsolution":
                    x.Email = "info@elsolution.hr";
                    x.Password = "Els456789$";
                    x.EmailName = "El. Solution";
                    x.ServerHost = "mail.elsolution.hr";
                    x.ServerPort = 25;
                    break;
                default:
                    break;
            }
            return x;
        }

        private Response SendMail(string sendTo, string subject, string body, MailSettings mailSetting)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailSetting.Email, mailSetting.EmailName);
                mail.To.Add(string.IsNullOrWhiteSpace(sendTo) ? mailSetting.Email : sendTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(mailSetting.ServerHost, mailSetting.ServerPort);
                NetworkCredential Credentials = new NetworkCredential(mailSetting.Email, mailSetting.Password);
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
                // TODO: error log
                return r;
            }
        }
    }
}