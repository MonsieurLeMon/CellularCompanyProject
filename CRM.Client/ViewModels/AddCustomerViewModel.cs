using Common.Models;
using Common.Validations;
using CRM.BL.CrmServices;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Client.ViewModels
{
    public class AddCustomerViewModel
    {
        public AddCustomerViewModel()
        {
            Validate = new ValidateStringInput();
            Service = new CustomerServices();
        }

        #region Properties And Instances
        public ValidationResult FNameValidation { get; set; }
        public ValidationResult LNameValidation { get; set; }
        public ValidationResult PhoneLengthValidation { get; set; }
        public ValidationResult PhoneInputValidation { get; set; }
        public ValidationResult PasswordValidation { get; set; }
        public ValidationResult AddressValidation { get; set; }
        public ValidationResult EmailAddressValidation { get; set; }

        private ValidateStringInput Validate { get; set; }
        private CustomerServices Service { get; set; }
        #endregion

        #region Validations
        public bool ValidateInput(string fName, string lName,
            string password, string phone, string address, string email)
        {
            List<ValidationResult> results = ReturnValidations(fName, lName,
                password, phone, address, email).ToList();

            foreach (var res in results)
            {
                if (!res.Result)
                    return false;
            }
            return true;
        }

        private IEnumerable<ValidationResult> ReturnValidations(string fName, string lName,
            string password, string phone, string address, string email)
        {
            var results = new List<ValidationResult>();

            FNameValidation = Validate.ValidateNameLength(fName);
            LNameValidation = Validate.ValidateNameLength(lName);
            PhoneLengthValidation = Validate.ValidatePhoneNumberLength(phone);
            PhoneInputValidation = Validate.ValidatePhoneNumberInput(phone);
            PasswordValidation = Validate.ValidatePasswordLength(password);
            AddressValidation = Validate.ValidateAddressLength(address);
            EmailAddressValidation = Validate.ValidateEmailLength(email);

            results.Add(FNameValidation);
            results.Add(LNameValidation);
            results.Add(PhoneLengthValidation);
            results.Add(PhoneInputValidation);
            results.Add(PasswordValidation);
            results.Add(AddressValidation);
            results.Add(EmailAddressValidation);

            return results;
        }
        #endregion

        public CreateCustomerResult AddCustomer(string fName, string lName, string password, string phone, string address, string email)
        {
            var customer = new CustomerModel
            {
                FirstName = fName,
                LastName = lName,
                Password = password,
                PhoneNumber = phone,
                Address = address,
                EmailAddress = email,
                IsActive = true
            };

            var result = Service.AddCustomer(customer);
            return result;
        }

        public CreateCustomerResult AddCustomer(CustomerModel customer)
        {
            var result = Service.AddCustomer(customer);
            return result;
        }
    }
}
