using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SendEmailService: ISendEmail
    {
        private readonly ILogger<SendEmailService> _logger;
        private readonly IPersona _persona;
        private readonly IConfiguration _configuration;

        public SendEmailService(ILogger<SendEmailService> logger, IPersona persona, IConfiguration configuration)
        {
            _logger = logger;
            _persona = persona;
            _configuration = configuration;
        }

        public List<string> EnviarCorreo() 
        {
            List<string> response = new List<string>();
            string emailOrigin = _configuration.GetSection("EmailCredentials:email").Value;
            string password = _configuration.GetSection("EmailCredentials:password").Value;

            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigin, password);

                List<EmpleadoVM> empleadoVMs = _persona.ObtenerEmpleados();

                empleadoVMs.ForEach(empleadoVM =>
                {
                    MailMessage mailMessage = new MailMessage(emailOrigin, empleadoVM.Email);
                    mailMessage.Subject = "Bienvenido a SOA-P1-29AV";
                    mailMessage.Body = $"<h2>Te damos a la bienvenida a SOA-P1-28AV</h2><br><b>{empleadoVM.Nombre} {empleadoVM.apellidos}</b>";
                    mailMessage.IsBodyHtml = true;
                    smtpClient.Send(mailMessage);
                    response.Add($"Correo enviado a {empleadoVM.Nombre} {empleadoVM.apellidos} Correo: {empleadoVM.Email}");
                });

                smtpClient.Dispose();

            } catch (Exception e)
            {
                response.Add(e.Message);
                _logger.LogError(e.Message);
            }

            return response;
        }
    }
}
