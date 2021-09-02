namespace api.Models
{
    public class Mail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Msg { get; set; }
        public string SendTo { get; set; }
        public string Owner { get; set; }
        public Response Resp { get; set; }
    }

    public class Response
    {
        public bool IsSent { get; set; }
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
}