using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BL.BillCalulator
{
    public class BillCalculator
    {
        public double CalculatePriceForBill(IEnumerable<LineModel> lines, IEnumerable<PackageModel> packages, IEnumerable<CallModel> calls, IEnumerable<SMSModel> smss)
        {
            double calculatedPrice = 0;
            

            foreach (var line in lines)
            {
                


            }


            return calculatedPrice;
        }
    }
}
