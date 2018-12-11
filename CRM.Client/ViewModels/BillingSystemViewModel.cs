using CRM.BL.CrmServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Client.ViewModels
{
    public class BillingSystemViewModel
    {
        public BillingSystemViewModel()
        {
            Service = new BillingSystemServices();
        }
        private BillingSystemServices Service { get; set; }

        public bool GenerateCalls()
        {
            if (Service.GenerateCalls())
                return true;
            return false;
        }

        public bool GenerateSMSs()
        {
            if (Service.GenerateSMSs())
                return true;
            return false;
        }
    }
}
