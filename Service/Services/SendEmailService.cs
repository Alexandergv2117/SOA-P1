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
        private string emailOrigin = "roboga2117dev@gmail.com";
        private string emailAddress = "roboga2117dev@gmail.com";
        private string password = "yuifqahrhnvbyodv";

        public SendEmailService(ILogger<SendEmailService> logger)
        {
            _logger = logger;
        }

        public string EnviarCorreo() 
        {
            string response = "";

            try
            {
                MailMessage mailMessage = new MailMessage(emailOrigin, emailAddress, "Camara mi niño", "<b>Pongase chupas</b>");

                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigin, password);

                smtpClient.Send(mailMessage);
                smtpClient.Dispose();

                response = "Enviado";
            } catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
    }
}
