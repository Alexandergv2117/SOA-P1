using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly IAuth _auth;
        private readonly IConfiguration _configuration;

        public AuthController(ISendEmail sendEmail, IAuth auth, IConfiguration configuration)
        {
            _auth = auth;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Send([FromBody] Usuario user)
        {
            return Ok(_auth.ValidCredentials(user));
        }
    }
}
