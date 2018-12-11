using Common.Models;
using CRM.BL.CrmServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CRM.Client.ViewModels
{
    public class AddLineAndPackageViewModel
    {
        public AddLineAndPackageViewModel()
        {
            LService = new LineServices();
            PService = new PackageServices();
        }

        private LineServices LService { get; set; }
        private PackageServices PService { get; set; }

        public CreateLineResult AddLine(string lineNumber, int customerId)
        {
            LineModel line = new LineModel
            {
                LineNumber = lineNumber,
                CustomerId = customerId
            };

            var result = LService.AddLine(line);

            return result;
        }

        public bool AddPackageToLine(int lineId, string packageName, double baseMinutePrice, double baseSMSPrice, double packagePrice, int amountOfMinutes, int amountOfSms)
        {
            var newPackage = new MinutesBankPackageModel
            {
                PackageName = packageName,
                BasePricePerMinute = baseMinutePrice,
                BasePricePerSMS = baseSMSPrice,
                DateActivated = DateTime.Now,
                MinutesBankPrice = packagePrice,
                AmountOfMinutesInPackage = amountOfMinutes,
                AmountOfSmsInPackage = amountOfSms,
            };

            if (PService.AddPackageToLine(newPackage, lineId))
                return true;
            return false;
        }

        public bool AddPackageToLine(int lineId, string packageName, double baseMinutePrice, double baseSMSPrice, double specialMinutePrice, double specialSMSPrice)
        {
            var newPackage = new SpecialPricePackageModel
            {
                PackageName = packageName,
                BasePricePerMinute = baseMinutePrice,
                BasePricePerSMS = baseSMSPrice,
                DateActivated = DateTime.Now,
                PackagePricePerMinute = specialMinutePrice,
                PackagePricePerSMS = specialSMSPrice
            };

            if (PService.AddPackageToLine(newPackage, lineId))
                return true;
            return false;
        }

    }
}
