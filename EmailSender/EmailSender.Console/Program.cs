using Autofac;
using EmailSender.Console.Abstract;
using EmailSender.Console.Concrete;
using MailKit;

internal class Program
{
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
}