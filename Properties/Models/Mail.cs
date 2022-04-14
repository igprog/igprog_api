using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Phone { get; set; }

        [Required]
        public string Msg { get; set; }

        [Required]
        public string SendTo { get; set; }

        [Required]
        public string Owner { get; set; }
        // public Response Resp { get; set; }
    }

    // public class Response
    // {
    //     public bool IsSent { get; set; }
    //     public string Msg { get; set; }
    //     public string Msg1 { get; set; }
    // }

    // public class MailSettings
    // {
    //     public string Email { get; set; }
    //     public string Password { get; set; }
    //     public string EmailName { get; set; }
    //     public string ServerHost { get; set; }
    //     public int ServerPort { get; set; }

    // }
}