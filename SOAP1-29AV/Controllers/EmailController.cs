using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/v1/email")]
    public class EmailController : Controller
    {
        private readonly ISendEmail _sendEmail;

        public EmailController(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        [HttpGet]
        [Route("sendEmails")]
        public IActionResult Index()
        {
            return Ok(_sendEmail.EnviarCorreo());
        }
    }
}
