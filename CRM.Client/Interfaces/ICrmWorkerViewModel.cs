using Common.Models;
using System.Collections.Generic;

namespace CRM.Client.Interfaces
{
    public interface ICrmWorkerViewModel
    {
        CustomerModel GetCustomerDetails(int id);

        IEnumerable<CustomerModel> FindCustomers(string searchInput);
    }
}
