using EmailSender.Console.Abstract;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
namespace EmailSender.Console.Concrete
{
    public class EmailManager : IEmailService
    { 
        public async Task SendEmail(string fromMail, string toMail, string htmlBody, string subject, string mailNotificationHeader)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com");
                client.Authenticate("mustafaulas1986@gmail.com", "your gmail password");

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = htmlBody

                };
                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress(mailNotificationHeader, fromMail));
                message.To.Add(new MailboxAddress("Blog Email", toMail));
                message.Subject = subject;

                try
                {
                    var res = client.Send(message);
                }
                catch (Exception)
                {

                    throw new NotImplementedException();
                }
           
                client.Disconnect(true);
            }
           
        }
    }
}
