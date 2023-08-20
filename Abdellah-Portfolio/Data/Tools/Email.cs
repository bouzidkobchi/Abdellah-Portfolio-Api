using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
namespace Abdellah_Portfolio.Data.Tools
{
    public class Email
    {
        static void sendEmail(string sender, string password, string reciever, string message)
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(sender));
            email.To.Add(MailboxAddress.Parse(reciever));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>{message}</h1>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate($"{sender}", $"{password}");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
