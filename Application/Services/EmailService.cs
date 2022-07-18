
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class EmailService
    {


        public Task Execute(string EmailUser , string Body , string Title)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 1000000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("faezehjafarpour75@gmail.com", "ppppp");
            MailMessage message = new MailMessage();
            message.Subject = Title;
            message.Body = Body;
            message.From = new MailAddress("faezehjafarpour75@gmail.com");
            message.To.Add(EmailUser);
            message.IsBodyHtml = true;
            client.Send(message);
            return Task.CompletedTask;
        }
        
    }
}
