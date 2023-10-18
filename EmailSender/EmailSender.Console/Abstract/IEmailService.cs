using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Console.Abstract
{
    public  interface IEmailService
    {
      Task  SendEmail(string fromMail, string toMail, string htmlBody, string subject, string mailNotificationHeader);
    }
}
