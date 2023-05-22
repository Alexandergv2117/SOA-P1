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
        private readonly IValidEmail _validEmail;
        private readonly IConfiguration _configuration;

        public EmailController(ISendEmail sendEmail, IValidEmail validEmail, IConfiguration configuration)
        {
            _sendEmail = sendEmail;
            _validEmail = validEmail;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("sendEmails")]
        public IActionResult Index()
        {
            return Ok(_sendEmail.EnviarCorreo());
        }

        [HttpPost]
        [Route("validCredentials")]
        public IActionResult Send([FromBody] MiModelo modelo)
        {
            return Ok(_validEmail.ValidarCorreo());
        }
    }
}
