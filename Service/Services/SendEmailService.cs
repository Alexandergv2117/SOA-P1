using Domain.Entities;
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

        private string emailOrigin = "roboga2117dev@gmail.com";
        private string password = "yuifqahrhnvbyodv";

        public SendEmailService(ILogger<SendEmailService> logger, IPersona persona)
        {
            _logger = logger;
            _persona = persona;
        }

        public string EnviarCorreo() 
        {
            string response = "";

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
                    mailMessage.Body = $"<h2>Te damos a la bienvenida a SOA-P1-28AV</h2><br><b>{empleadoVM.Nombre} {empleadoVM}</b>";
                    mailMessage.IsBodyHtml = true;
                    smtpClient.Send(mailMessage);
                });

                smtpClient.Dispose();

                response = "Enviado";
            } catch (Exception e)
            {
                response = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
    }
}
