using Common.Models;
using DAL.Db.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Converters;
using BillingSystem.BL.BillCalulator;

namespace BillingSystem.BL.BillGenerator
{
    public class BillGenerator
    {
        #region ctor
        public BillGenerator()
        {
            BillingMonth = (DateTime.Now.Month - 1);
            BillingYear = (DateTime.Now.Year - 1);
            ConvertDbToProgram = new ConvertFromDbToProgramModel();
            ConvertProgramToDb = new ConvertFromProgramToDb();
            URepo = new UserRepository();
            ARepo = new ActivitiesRepository();
            Calculator = new BillCalculator();
            NewBills = new List<BillModel>();
        }
        public BillGenerator(int month, int year)
        {
            BillingMonth = month;
            BillingYear = year;
            ConvertDbToProgram = new ConvertFromDbToProgramModel();
            ConvertProgramToDb = new ConvertFromProgramToDb();
            URepo = new UserRepository();
            ARepo = new ActivitiesRepository();
            Calculator = new BillCalculator();
            NewBills = new List<BillModel>();
        }
        #endregion

        private int BillingMonth { get; set; }
        private int BillingYear { get; set; }
        private ConvertFromDbToProgramModel ConvertDbToProgram { get; set; }
        private ConvertFromProgramToDb ConvertProgramToDb { get; set; }
        private UserRepository URepo { get; set; }
        private ActivitiesRepository ARepo { get; set; }
        private BillCalculator Calculator { get; set; }
        private List<BillModel> NewBills { get; set; }

        public void GenerateBillsForAllCustomers()
        {
            IEnumerable<CustomerModel> allCustomers = GetAllCustomers();

            foreach (var customer in allCustomers)
            {
                BillModel newBill = StartGeneratingBill(customer);
                var calls = new List<CallModel>();
                var smss = new List<SMSModel>();

                foreach (var line in newBill.Lines)
                {
                    calls.AddRange(GetCallsForBill(line.LineId, BillingMonth, BillingYear));
                    smss.AddRange(GetSmssForBill(line.LineId, BillingMonth, BillingYear));
                }

                newBill.TotalPrice = Calculator.CalculatePriceForBill(newBill.Lines, newBill.Packages, calls, smss);
                NewBills.Add(newBill);
            }

            SaveBilltoDb(NewBills);

        }

        // fills basic info that doesn't need calculations to bill
        private BillModel StartGeneratingBill(CustomerModel customer)
        {

            BillModel newBill = new BillModel();
            newBill.CustomerId = customer.UserId;
            newBill.CustomerName = string.Format($"{customer.FirstName} {customer.LastName}");
            newBill.Month = BillingMonth;
            newBill.Year = BillingYear;
            newBill.Lines = customer.Lines;
            newBill.Packages = new List<PackageModel>();
            foreach (var line in customer.Lines)
            {
                newBill.Packages.AddRange(line.Packages);
            }
            return newBill;
        }

        #region Get from Db Methods
        private IEnumerable<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> allCustomers = new List<CustomerModel>();
            List<CustomerEntity> allCustomersFromDb = new List<CustomerEntity>();

            allCustomersFromDb = URepo.GetAllCustomers().ToList();

            allCustomers = ConvertDbToProgram.ConvertCustomer(allCustomersFromDb).ToList();

            return allCustomers;
        }

        private IEnumerable<CallModel> GetCallsForBill(int id, int month, int year)
        {
            var calls = new List<CallModel>();
            var dbCalls = ARepo.GetCallsForLineForMonth(id, month, year);
            calls = ConvertDbToProgram.ConvertCall(dbCalls).ToList();
            return calls;
        }

        private IEnumerable<SMSModel> GetSmssForBill(int id, int month, int year)
        {
            var smss = new List<SMSModel>();
            var dbSMSs = ARepo.GetSMSsForLineForMonth(id, month, year);
            smss = ConvertDbToProgram.ConvertSMS(dbSMSs).ToList();
            return smss;
        }
        #endregion

        #region Save To Db Methods
        private bool SaveBilltoDb(BillModel billToSave)
        {
            var repo = new BillRepository();
            var convertedBill = ConvertProgramToDb.ConvertBill(billToSave);
            repo.AddBill(convertedBill);
            return true;
        }

        private bool SaveBilltoDb(IEnumerable<BillModel> billsToSave)
        {
            var repo = new BillRepository();
            var convertedBills = ConvertProgramToDb.ConvertBill(billsToSave);
            repo.AddBill(convertedBills);
            return true;
        }
        #endregion
    }
}