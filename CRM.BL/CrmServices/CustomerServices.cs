using Common.Models;
using Converters;
using DAL.Db.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BL.CrmServices
{
    public class CustomerServices
    {
        public CustomerServices()
        {
            Repo = new UserRepository();
            FromDbToModel = new ConvertFromDbToProgramModel();
            FromModelToDb = new ConvertFromProgramToDb();
        }

        #region instances
        private string customerCreated = "Customer Created";
        private string customerExist = "Customer Exist";
        private string customerFailed = "Failed To Create Customer";
        private UserRepository Repo { get; set; }
        private ConvertFromDbToProgramModel FromDbToModel { get; set; }
        private ConvertFromProgramToDb FromModelToDb { get; set; }
        #endregion

        #region Get Methods
        public CustomerModel GetCustomer(int id)
        {
            var dbCustomer = Repo.GetCustoemrById(id);
            var convertedCustomer = FromDbToModel.ConvertCustomer(dbCustomer);
            return convertedCustomer;
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            var dbList = Repo.GetAllCustomers();
            var convertedList = ConvertCustomer(dbList);
            return convertedList;
        }

        public IEnumerable<CustomerModel> FindCustomers(string searchInput)
        {
            var dbCollection = Repo.GetFilteredCustomers(searchInput);
            var filteredCollection = ConvertCustomer(dbCollection);
            return filteredCollection;
        }
        #endregion

        public CreateCustomerResult AddCustomer(CustomerModel customer)
        {
            var result = new CreateCustomerResult();
            if (Repo.IsCustomerExistByPhoneNumber(customer.PhoneNumber))
            {
                result.IsCreated = false;
                result.Description = customerExist;
            }
            else
            {
                var convertedCustomer = ConvertCustomer(customer);
                if (Repo.AddUser(convertedCustomer))
                {
                    result.IsCreated = true;
                    result.Id = Repo.GetCustomerByPhoneAndPassword(customer.PhoneNumber, customer.Password).UserId;
                    result.Description = customerCreated;
                }
                else
                {
                    result.IsCreated = false;
                    result.Description = customerFailed;
                }
            }
            return result;
        }

        #region Converts
        private CustomerModel ConvertCustomer(CustomerEntity customerEntity)
        {
            var customerModel = FromDbToModel.ConvertCustomer(customerEntity);
            return customerModel;
        }

        private CustomerEntity ConvertCustomer(CustomerModel customerModel)
        {
            var customerEntity = FromModelToDb.ConvertCustomer(customerModel);
            return customerEntity;
        }

        private IEnumerable<CustomerModel> ConvertCustomer(IEnumerable<CustomerEntity> cstEntityCollection)
        {
            var cstModelCollection = FromDbToModel.ConvertCustomer(cstEntityCollection);
            return cstModelCollection;
        }

        private IEnumerable<CustomerEntity> ConvertCustomer(IEnumerable<CustomerModel> cstModelCollection)
        {
            var cstEntityCollection = FromModelToDb.ConvertCustomer(cstModelCollection);
            return cstEntityCollection;
        }
        #endregion
    }
}
