using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly ISendEmail _sendEmail;
        private readonly IValidEmail _validEmail;

        public EmailController(ISendEmail sendEmail, IValidEmail validEmail)
        {
            _sendEmail = sendEmail;
            _validEmail = validEmail;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_sendEmail.EnviarCorreo());
        }

        [HttpPost]
        public IActionResult Send([FromBody] MiModelo modelo)
        {
            return Ok(_validEmail.ValidarCorreo());
        }
    }
}
