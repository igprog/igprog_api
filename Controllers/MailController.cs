using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Attributes;  // ApiKey: https://www.codeproject.com/Articles/5287482/Secure-ASP-NET-Core-Web-API-using-API-Key-Authenti

namespace api.Controllers
{
    [Route("api/mail")]
    [ApiController]
    [ApiKey]
    public class MailController : ControllerBase
    {
        private readonly IMail _repository;

        public MailController(IMail repository)
        {
            _repository = repository;
        }
 
        [Route("~/api/mail/init")]
        [HttpGet]
        public ActionResult InitMail()
        {
            var x = new Mail();
            // x.Resp = new Response();
            return Ok(x);
        }

        [Route("~/api/mail/send")]
        [HttpPost]
        public ActionResult SendMail([FromBody] Mail mail)
        {
            var x = _repository.SendMail(mail);
            return Ok(x);
        }

        [Route("~/api/mail/getall")]
        [HttpGet]
        public ActionResult GetAllMails()
        {
            var x = _repository.GetAllMails();
            return Ok(x);
        }

        // https://localhost:5001/api/mail/get/1
        [Route("~/api/mail/get/{id}")]
        [HttpGet]
        public ActionResult GetMailById(int id)
        {
            var x = _repository.GetMailById(id);
            return Ok(x);
        }

    }

}