using System.Collections.Generic;
using DAL.Db.Entities;
using Common.Models;

namespace Converters
{
    public class ConvertFromDbToProgramModel
    {
        #region Customer
        public CustomerModel ConvertCustomer(CustomerEntity originalCustomer)
        {
            CustomerModel converterdCustomer = new CustomerModel
            {
                UserId = originalCustomer.UserId,
                FirstName = originalCustomer.FirstName,
                LastName = originalCustomer.LastName,
                PhoneNumber = originalCustomer.PhoneNumber,
                Password = originalCustomer.Password,
                Address = originalCustomer.Address,
                EmailAddress = originalCustomer.EmailAddress,
                Customer_Type = originalCustomer.Customer_Type,
                IsActive = originalCustomer.IsActive,
            };

            return converterdCustomer;
        }

        public IEnumerable<CustomerModel> ConvertCustomer(IEnumerable<CustomerEntity> originalCollection)
        {
            var convertedCollection = new List<CustomerModel>();
            foreach (var c in originalCollection)
            {
                convertedCollection.Add(ConvertCustomer(c));
            }
            return convertedCollection;
        }
        #endregion

        #region Employee
        public EmployeeModel ConvertEmployee(EmployeeEntity originalEmployee)
        {
            EmployeeModel convertedEmployee = new EmployeeModel();

            return convertedEmployee;
        }

        public IEnumerable<EmployeeModel> ConvertEmployee(IEnumerable<EmployeeEntity> originalCollection)
        {
            var convertedCollection = new List<EmployeeModel>();
            foreach (var e in originalCollection)
            {
                convertedCollection.Add(ConvertEmployee(e));
            }
            return convertedCollection;
        }
        #endregion

        #region Bill
        public BillModel ConvertBill(BillEntity originalBill)
        {
            BillModel convertedBill = new BillModel
            {
                BillId = originalBill.BillId,
                CustomerId = originalBill.CustomerId,
                CustomerName = originalBill.CustomerName,
                Month = originalBill.Month,
                Year = originalBill.Year,
                TotalPrice = originalBill.TotalPrice,
                Lines = new List<LineModel>(),
                Packages = new List<PackageModel>()
            };

            return convertedBill;
        }

        public IEnumerable<BillModel> ConvertBill(IEnumerable<BillEntity> originalCollection)
        {
            var convertedCollection = new List<BillModel>();

            foreach (var b in originalCollection)
            {
                convertedCollection.Add(ConvertBill(b));
            }
            return convertedCollection;
        }
        #endregion

        #region Call
        public CallModel ConvertCall(CallEntity originalCall)
        {
            CallModel convertedCall = new CallModel
            {
                Id = originalCall.CallId,
                LineId = originalCall.LineId,
                DateActivityMade = originalCall.DateCreated,
                DestinationNumber = originalCall.DestinationNumber,
                Duration = originalCall.Duration
            };

            return convertedCall;
        }

        public IEnumerable<CallModel> ConvertCall(IEnumerable<CallEntity> originalCollection)
        {
            var convertedCollection = new List<CallModel>();
            foreach (var c in originalCollection)
            {
                convertedCollection.Add(ConvertCall(c));
            }
            return convertedCollection;
        }
        #endregion

        #region SMS
        public SMSModel ConvertSMS(SMSEntity originalSMS)
        {
            SMSModel convertedSMS = new SMSModel
            {
                Id = originalSMS.SMSId,
                LineId = originalSMS.LineId,
                DateActivityMade = originalSMS.DateCreated,
                DestinationNumber = originalSMS.DestinationNumber
            };

            return convertedSMS;
        }

        public IEnumerable<SMSModel> ConvertSMS(IEnumerable<SMSEntity> originalCollection)
        {
            var convertedCollection = new List<SMSModel>();
            foreach (var s in originalCollection)
            {
                convertedCollection.Add(ConvertSMS(s));
            }
            return convertedCollection;
        }
        #endregion

        #region Line
        public LineModel ConvertLine(LineEntity originalLine)
        {
            LineModel convertedLine = new LineModel
            {
                LineId = originalLine.LineId,
                CustomerId = originalLine.UserId,
                LineNumber = originalLine.LineNumber
            };
            return convertedLine;
        }

        public IEnumerable<LineModel> ConvertLine(IEnumerable<LineEntity> originalCollection)
        {
            var convertedCollection = new List<LineModel>();
            foreach (var line in originalCollection)
            {
                convertedCollection.Add(ConvertLine(line));
            }
            return convertedCollection;
        }
        #endregion

        #region MinutesPackage
        public MinutesBankPackageModel ConvertMinutesPackage(MinutesBankPackageEntity originalPackage)
        {
            var convertedPackage = new MinutesBankPackageModel
            {
                PackageId = originalPackage.PackageId,
                PackageName = originalPackage.PackageName,
                BasePricePerMinute = originalPackage.BasePricePerMinute,
                BasePricePerSMS = originalPackage.BasePricePerSMS,
                DateActivated = originalPackage.DateActivated,
                DateCancled = originalPackage.DateCancled,
                MinutesBankPrice = originalPackage.MinutesBankPrice,
                AmountOfMinutesInPackage = originalPackage.AmountOfMinutesInPackage,
                AmountOfSmsInPackage = originalPackage.AmountOfSmsInPackage
            };
            return convertedPackage;
        }
        #endregion

        #region SpecialPricePackage
        public SpecialPricePackageModel ConvertMinutesPackage(SpecialPricePackageEntity originalPackage)
        {
            var convertedPackage = new SpecialPricePackageModel
            {
                PackageId = originalPackage.PackageId,
                PackageName = originalPackage.PackageName,
                BasePricePerMinute = originalPackage.BasePricePerMinute,
                BasePricePerSMS = originalPackage.BasePricePerSMS,
                DateActivated = originalPackage.DateActivated,
                DateCancled = originalPackage.DateCancled,
                PackagePricePerMinute = originalPackage.PackagePricePerMinute,
                PackagePricePerSMS = originalPackage.PackagePricePerSMS
            };
            return convertedPackage;
        }
        #endregion
    }
}
