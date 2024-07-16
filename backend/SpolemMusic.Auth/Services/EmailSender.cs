using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace SpolemMusic.Auth.Services
{
    public class EmailSender
    {
        public void SendVerificationEmail(string email, string subject, string content)
        {
            string fromMail = "spolemmusic.company@gmail.com";
            string fromPassword = "yzczimmjwkkgclde";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = content;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

              smtpClient.Send(message);

        }
    }
}
