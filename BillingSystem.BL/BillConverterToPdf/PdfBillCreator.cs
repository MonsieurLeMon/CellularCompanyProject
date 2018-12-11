using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace BillingSystem.BL.BillConverterToPdf
{
    public class PdfBillCreator
    {
        private string Path { get; set; }
        public PdfBillCreator(BillModel bill)
        {
            CreatePDF(bill);
            Path = "c:\\pdfFiles";
        }

        public void CreatePDF(BillModel bill)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = $"{bill.Month}-{bill.Year} Bill";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Helvetica", 20, XFontStyle.Bold);
            graph.DrawString($"Customer: {bill.CustomerName}{Environment.NewLine} Customer Id: {bill.CustomerId}{Environment.NewLine}" +
                $"Total Price: {bill.TotalPrice}{Environment.NewLine}",
                font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            string pdfFilename = $"bill{bill.CustomerName}{bill.Month}{bill.Year}.pdf";
            pdf.Save(pdfFilename);
        }
    }
}
