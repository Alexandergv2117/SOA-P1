using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.IServices;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ValidEmailService : IValidEmail
    {
        private readonly ILogger<ValidEmailService> _logger;

        public ValidEmailService(ILogger<ValidEmailService> logger)
        {
            _logger = logger;
        }

        public string ValidarCorreo() 
        {
            return "Test";
        }
    }
}
