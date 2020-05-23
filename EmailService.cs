using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace PlurasightLogin
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            MailMessage client = new MailMessage();
            client.From = new MailAddress("Loginyen99@gmail.com", "Xac nhan");
            client.To.Add(message.Destination);
            client.Body = message.Body;
            client.Subject = message.Subject;
            client.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("Loginyen99@gmail.com", "yen$%no1");
            await smtp.SendMailAsync(client);
            return;

        }
    }
}