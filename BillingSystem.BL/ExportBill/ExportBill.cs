using Common.Models;
using DAL.Repositories;

namespace BillingSystem.BL.ExportBill
{
    public class ExportBill
    {
        private UserRepository Repo { get; set; }

        public ExportBill(BillModel bill)
        {
            Repo = new UserRepository();
            var email = Repo.GetCustoemrById(bill.CustomerId).EmailAddress;
            SendFile(bill, email);
        }

        private void SendFile(BillModel bill, string emailDestination)
        {
            EmailSender sender = new EmailSender("dudiolegdiamond@gmail.com", "Diamond1234", emailDestination);
            sender.CreateMailMessage($"Bill For {bill.Month}-{bill.Year}", "Bill Via Email");
            sender.AddAttachment($"C:\\pdfFiles\\bill{bill.CustomerName}{bill.Month}{bill.Year}.pdf");
            sender.AddSmtp();
            sender.SendEmail();
        }
    }
}
