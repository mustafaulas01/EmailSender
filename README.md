# Email Sender
In this project, I showed how to send an email in C# using Gmail SMTP.
## IEmailService

  `public  interface IEmailService{ Task  SendEmail(string fromMail, string toMail, string htmlBody, string subject, string mailNotificationHeader);}`

## EmailManager
  
  `public class EmailManager : IEmailService`
   
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


## Program.cs

  
   private  async static Task  Main(string[] args)
   
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<EmailManager>().As<IEmailService>();

        var container = containerBuilder.Build();

        string articleTitle = "How to make an email sending program with .net core ?";
        string editorName="Mustafa Ulas";
        string htmlBody = $"<p> Article Title:{articleTitle}</p> <p>Editor :{editorName} </p> <p> Date:{DateTime.Now} </p>";

        string sender = "mustafaulas1986@gmail.com";
        string to = "mustafaulas@windowslive.com";

        var _mailService = container.Resolve<IEmailService>();

        var result =  _mailService.SendEmail(sender,to,htmlBody,"Email sending with .NETCore","Mustafa Ulas Blog");

        if (result.IsCompleted)
        {
            Console.WriteLine("Email has sended");
            Console.ReadLine();
        }

    }
    
