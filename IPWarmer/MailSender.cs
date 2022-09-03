using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace IPWarmer
{
    internal class MailSender
    {
        public void Sender(string Server, string Username, string Password, int Port, List<string> TargetMails, int Piece, int Interval)
        {
            frmMain frmMain = new frmMain();
            var Email = new MimeMessage();
            var Smtp = new SmtpClient();

            /*SMTP Auth & Connection*/
            Smtp.Connect(Server, Port, true);
            Smtp.Authenticate(Username, Password);

            /*Email Creation*/
            Email.Subject = "Test";
            Email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<h1>Can u hear me ?</h1>" };

            /*Mail Sending*/
            Email.From.Add(MailboxAddress.Parse(Username));
            foreach (var Mail in TargetMails)
            {
                Email.To.Add(MailboxAddress.Parse(Mail));
                Smtp.Send(Email);
                frmMain.CurrentStep++;
            }
            Smtp.Disconnect(true);
        }
    }
}
