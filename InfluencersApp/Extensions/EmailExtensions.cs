using BusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InfluencersApp.Extensions
{
    public static class EmailExtensions
    {
        public static async Task SendEmail(this EmailViewModel viewModel, IConfiguration configuration)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = configuration["SmtpConfiguration:Host"];
                smtp.Port = Convert.ToInt32(configuration["SmtpConfiguration:Port"]);
                smtp.EnableSsl = configuration["SmtpConfiguration:EnableSSL"].ToLower() == "true";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential
                {
                    UserName = configuration["SmtpConfiguration:Username"],
                    Password = configuration["SmtpConfiguration:Password"]
                };

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(configuration["SmtpConfiguration:From"]);
                    message.To.Add(new MailAddress(viewModel.To));
                    message.Subject = viewModel.Subject;
                    message.Body = viewModel.Content;
                    message.IsBodyHtml = viewModel.IsHtml;

                    await smtp.SendMailAsync(message);
                }
            }
        }
    }
}
