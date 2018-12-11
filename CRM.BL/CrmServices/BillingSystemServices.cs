using BillingSystem.BL.ActivityGenerators;

namespace CRM.BL.CrmServices
{
    public class BillingSystemServices
    {
        public BillingSystemServices()
        {
            CallsGen = new CallsGenerator();
            SMSsGen = new SMSGenerator();
        }

        private CallsGenerator CallsGen { get; set; }
        private SMSGenerator SMSsGen { get; set; }

        public bool GenerateCalls()
        {
            if (CallsGen.GenerateCalls())
                return true;
            return false;
        }
        public bool GenerateSMSs()
        {
            if (SMSsGen.GenerateSMSs())
                return true;
            return false;
        }
    }
}
