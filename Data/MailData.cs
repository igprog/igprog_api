using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using api.Models;

namespace api.Data
{
    public class MailData : IMail
    {
        public class Response
        {
            public bool IsSuccess { get; set; }
            public string Msg { get; set; }
            public string Msg1 { get; set; }
        }

        public class MailSettings
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string EmailName { get; set; }
            public string ServerHost { get; set; }
            public int ServerPort { get; set; }

        }
        public Response SendMail(Mail x)
        {
            string body = $@"<div>Ime: {x.Name}</div>
            <div>Email: <a href=""mailto:{x.Email}?subject=Odgovor na upit"">{x.Email}</a></div>
            <div>Telefon: <a href=""tel:{x.Phone}"">{x.Phone}</a></div>
            <div>Poruka: {x.Msg}</div>";

            MailSettings mailSetting = GetMailSettings(x.Owner);

            Response resp = SendMail(x.SendTo, "Novi upit", body, mailSetting);
            return resp;
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
                    x.Email = "noreply@elsolution.hr";
                    x.Password = "Nes123456$";
                    x.EmailName = "El. Solution";
                    x.ServerHost = "mail.elsolution.hr";
                    x.ServerPort = 25;
                    break;
                case "apartmentverano":
                // TODO: apartmentverano (not working)
                    x.Email = "info@igprog.hr";
                    x.Password = "Ii123456$";
                    //x.EmailName = "IG PROG";
                    x.ServerHost = "mail.igprog.hr";
                    // x.Email = "info@apartmentverano.com";
                    // x.Password = "Iav123456$";
                    x.EmailName = "Apartment Verano";
                    // x.ServerHost = "mail.apartmentverano.com";
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
                r.IsSuccess = true;
                r.Msg = "Vaša poruka je uspješno poslana";
                r.Msg1 = "Odgovorit ćemo Vam u roku od 24h";
                return r;
            }
            catch (Exception e)
            {
                Response r = new Response();
                r.IsSuccess = false;
                r.Msg = e.Message;
                r.Msg1 = e.StackTrace;
                // TODO: error log
                return r;
            }
        }

        public IEnumerable<Mail> GetAllMails()
        {
            throw new NotImplementedException();
        }

        public Mail GetMailById(int id)
        {
            throw new NotImplementedException();
        }
    }
}