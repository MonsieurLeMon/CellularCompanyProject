using Common.Models;
using DAL.Db.Entities;
using System.Collections.Generic;

namespace Converters
{
    public class ConvertFromProgramToDb
    {
        #region Custoemr
        public CustomerEntity ConvertCustomer(CustomerModel originalCustomer)
        {
            CustomerEntity converterdCustomer = new CustomerEntity
            {
                UserId = originalCustomer.UserId,
                FirstName = originalCustomer.FirstName,
                LastName = originalCustomer.LastName,
                Password = originalCustomer.Password,
                PhoneNumber = originalCustomer.PhoneNumber,
                Address = originalCustomer.Address,
                EmailAddress = originalCustomer.EmailAddress,
                Customer_Type = originalCustomer.Customer_Type,
                IsActive = originalCustomer.IsActive
            };

            return converterdCustomer;
        }

        public IEnumerable<CustomerEntity> ConvertCustomer(IEnumerable<CustomerModel> originalCollection)
        {
            var convertedCollection = new List<CustomerEntity>();
            foreach (var c in originalCollection)
            {
                convertedCollection.Add(ConvertCustomer(c));
            }
            return convertedCollection;
        }
        #endregion

        #region Employee
        public EmployeeEntity ConvertEmployee(EmployeeModel originalEmployee)
        {
            EmployeeEntity convertedEmployee = new EmployeeEntity
            {
                UserId = originalEmployee.UserId,
                FirstName = originalEmployee.FirstName,
                LastName = originalEmployee.LastName,
                Username = originalEmployee.Username,
                Password = originalEmployee.Password,
                PhoneNumber = originalEmployee.PhoneNumber,
                Address = originalEmployee.Address,
                EmailAddress = originalEmployee.EmailAddress,
                Role = originalEmployee.Role,
                IsActive = originalEmployee.IsActive
            };
            return convertedEmployee;
        }

        public IEnumerable<EmployeeEntity> ConvertEmployee(IEnumerable<EmployeeModel> originalCollection)
        {
            var convertedCollection = new List<EmployeeEntity>();
            foreach (var e in originalCollection)
            {
                convertedCollection.Add(ConvertEmployee(e));
            }
            return convertedCollection;
        }
        #endregion

        #region Bill
        public BillEntity ConvertBill(BillModel originalBill)
        {
            BillEntity convertedBill = new BillEntity
            {
                BillId = originalBill.BillId,
                CustomerId = originalBill.CustomerId,
                CustomerName = originalBill.CustomerName,
                Month = originalBill.Month,
                Year = originalBill.Year,
                TotalPrice = originalBill.TotalPrice,
                Lines = new List<string>(),
                PackagesIds = new List<int>()
            };
            foreach (var line in originalBill.Lines)
            {
                convertedBill.Lines.Add(line.LineNumber);
            }
            foreach (var package in originalBill.Packages)
            {
                convertedBill.PackagesIds.Add(package.PackageId);
            }

            return convertedBill;
        }

        public IEnumerable<BillEntity> ConvertBill(IEnumerable<BillModel> originalCollection)
        {
            var convertedCollection = new List<BillEntity>();

            foreach (var b in originalCollection)
            {
                convertedCollection.Add(ConvertBill(b));
            }
            return convertedCollection;
        }
        #endregion

        #region Call
        public CallEntity ConvertCall(CallModel originalCall)
        {
            CallEntity convertedCall = new CallEntity
            {
                CallId = originalCall.Id,
                LineId = originalCall.LineId,
                DateCreated = originalCall.DateActivityMade,
                DestinationNumber = originalCall.DestinationNumber,
                Duration = originalCall.Duration
            };

            return convertedCall;
        }

        public IEnumerable<CallEntity> ConvertCall(IEnumerable<CallModel> originalCollection)
        {
            var convertedCollection = new List<CallEntity>();
            foreach (var c in originalCollection)
            {
                convertedCollection.Add(ConvertCall(c));
            }
            return convertedCollection;
        }
        #endregion

        #region SMS
        public SMSEntity ConvertSMS(SMSModel originalSMS)
        {
            SMSEntity convertedSMS = new SMSEntity
            {
                SMSId = originalSMS.Id,
                LineId = originalSMS.LineId,
                DateCreated = originalSMS.DateActivityMade,
                DestinationNumber = originalSMS.DestinationNumber
            };

            return convertedSMS;
        }

        public IEnumerable<SMSEntity> ConvertSMS(IEnumerable<SMSModel> originalCollection)
        {
            var convertedCollection = new List<SMSEntity>();
            foreach (var s in originalCollection)
            {
                convertedCollection.Add(ConvertSMS(s));
            }
            return convertedCollection;
        }
        #endregion

        #region Line
        public LineEntity ConvertLine(LineModel originalLine)
        {
            LineEntity convertedLine = new LineEntity
            {
                LineNumber = originalLine.LineNumber,
                UserId = originalLine.CustomerId
            };
            return convertedLine;
        }

        public IEnumerable<LineEntity> ConvertLine(IEnumerable<LineModel> originalCollection)
        {
            var convertedCollection = new List<LineEntity>();
            foreach (var line in originalCollection)
            {
                convertedCollection.Add(ConvertLine(line));
            }
            return convertedCollection;
        }
        #endregion

        #region MinutesPackage
        public MinutesBankPackageEntity ConvertMinutesPackage(MinutesBankPackageModel originalPackage)
        {
            var convertedPackage = new MinutesBankPackageEntity
            {
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
        public SpecialPricePackageEntity ConvertSpecialPackage(SpecialPricePackageModel originalPackage)
        {
            var convertedPackage = new SpecialPricePackageEntity
            {
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