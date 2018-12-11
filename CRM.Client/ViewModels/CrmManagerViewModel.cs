using Common.Models;
using CRM.BL.CrmServices;
using CRM.Client.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Client.ViewModels
{
    public class CrmManagerViewModel : ICrmWorkerViewModel
    {
        public CrmManagerViewModel()
        {
            Services = new CustomerServices();
        }

        private CustomerServices Services { get; set; }

        public CustomerModel GetCustomerDetails(int id)
        {
            var customer = Services.GetCustomer(id);
            return customer;
        }

        public IEnumerable<CustomerModel> FindCustomers(string searchInput)
        {
            var filteredCustomers = new List<CustomerModel>();
            return filteredCustomers = Services.FindCustomers(searchInput).ToList();
        }
    }
}
