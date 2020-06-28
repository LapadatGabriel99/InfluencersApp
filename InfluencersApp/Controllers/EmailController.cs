using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace InfluencersApp.Controllers
{
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;

        private readonly IConfiguration _configuration;

        public EmailController(ILogger<EmailController> logger, IConfiguration configuration)
        {
            _logger = logger;

            _configuration = configuration;
        }

        [HttpGet("email/sendEmail/{viewModel}")]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = _configuration["SmtpConfiguration:Host"];
                smtp.Port = Convert.ToInt32(_configuration["SmtpConfiguration:Port"]);
                smtp.EnableSsl = _configuration["SmtpConfiguration:EnableSSL"].ToLower() == "true";
                smtp.Credentials = new NetworkCredential
                {
                    UserName = _configuration["SmtpConfiguration:Username"],
                    Password = _configuration["SmtpConfiguration:Password"]
                };

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(_configuration["SmtpConfiguration:From"]);
                    message.To.Add(new MailAddress(viewModel.To));
                    message.Subject = viewModel.Subject;
                    message.Body = viewModel.Content;
                    message.IsBodyHtml = viewModel.IsHtml;

                    smtp.Send(message);
                }                            

                return Ok();
            }
        }
    }
}
