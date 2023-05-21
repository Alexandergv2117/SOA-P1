using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly ISendEmail _sendEmail;

        public EmailController(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_sendEmail.EnviarCorreo());
        }
    }
}
