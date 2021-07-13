﻿using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebShop.Services.Contracts;

namespace WebShop.Services
{
    public class EmailSender : ICustomEmailSender
    {
        private readonly IConfiguration configuration;
        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, "Dear Client"));
                message.From = new MailAddress("support@webshop.net", "WebShop support team");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                var key = this.configuration["SendGridApiKey:Key"];

                using (var client = new SmtpClient("smtp.sendgrid.net"))
                {
                    client.Port = 587;
                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential("apikey", key);
                    client.Send(message);
                }
            }

            return Task.CompletedTask;
        }

        public async Task SendEmailsAsync(
            string email,
            string subject,
            string imagePath,
            string htmlMessage)
        {
            var from = new EmailAddress("support@webshop.net", "WebShop support team");
            var subj = subject;
            var to = new EmailAddress(email, "Dear Client");
            var body = htmlMessage;
            SendGridMessage message = MailHelper.CreateSingleEmail(from, to, subject, body, htmlMessage);
            var bytes = File.ReadAllBytes(@"C:\Users\Ivan\Downloads\" + imagePath);
            var file = Convert.ToBase64String(bytes);
            message.AddAttachment("picture.jpg", file);
            

            var key = this.configuration["SendGridApiKey:Key"];
            var client = new SendGridClient(key);

            var result = await client.SendEmailAsync(message);
        }
    }
}
