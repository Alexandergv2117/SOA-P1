using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthService : IAuth
    {
        private readonly ILogger<AuthService> _logger;
        private readonly PersonaRepositorio personaRepositorio;

        public AuthService(ILogger<AuthService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
        }

        public string ValidCredentials(Usuario user) 
        {
            bool isValidCredentials = personaRepositorio.validCredentials(user.email, user.password);

            if (isValidCredentials)
            {
                return "Usuario y contraseña correctos";
            }

            return "Usuario y/o contraseña incorectos";
        }
    }
}
