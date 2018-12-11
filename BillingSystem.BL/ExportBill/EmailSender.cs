using System;
using Spire.Email;
using Spire.Email.IMap;
using Spire.Email.Smtp;

namespace BillingSystem.BL.ExportBill
{
    public class EmailSender
    {
        public MailAddress FromAddress { get; set; }
        public MailAddress ToAddress { get; set; }
        public MailMessage Message { get; set; }
        public SmtpClient Smtp { get; set; }
        public string Password { get; set; }

        public EmailSender(string from, string password, string to)
        {
            FromAddress = new MailAddress(from);
            ToAddress = new MailAddress(to);
            Password = password;
        }

        public void CreateMailMessage(string subject, string body)
        {
            Message = new MailMessage(FromAddress, ToAddress);
            Message.Subject = subject;
            Message.BodyText = body;
        }

        public void AddAttachment(string filePath)
        {
            Message.Attachments.Add(new Attachment(filePath));
        }

        public void AddSmtp()
        {
            Smtp = new SmtpClient();
            Smtp.Host = "smtp.gmail.com";
            Smtp.ConnectionProtocols = ConnectionProtocols.Ssl;
            Smtp.Username = FromAddress.Address;
            Smtp.Password = Password;
            Smtp.Port = 587;
        }

        public void SendEmail()
        {
            Smtp.SendOne(Message);
        }
    }
}
