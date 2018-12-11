using Common.Models;
using Common.Validations;
using Converters;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Common.Models;

namespace Web.BL.Services
{
    public class Services
    {
        private ValidateStringInput StringValidation { get; set; }
        private UserRepository URepository { get; set; }
        private ConvertFromDbToProgramModel FromDbToProgram { get; set; }
        private ConvertFromProgramToDb FromProgramToDb { get; set; }

        public Services()
        {
            StringValidation = new ValidateStringInput();
            URepository = new UserRepository();
            FromDbToProgram = new ConvertFromDbToProgramModel();
            FromProgramToDb = new ConvertFromProgramToDb();
        }

        public CustomerModel LogIn(UserLoginModel user)
        {
            if (ValidateLoginInput(user))
            {
                var dbCustoemr = URepository.GetCustomerByPhoneAndPassword(user.PhoneNumber, user.Password);
                var convertedCustomer = FromDbToProgram.ConvertCustomer(dbCustoemr);
                return convertedCustomer;
            }
            else
            {
                return null;
                // write to log info - attempt to log in unsuccessful
            }
        }

        private bool ValidateLoginInput(UserLoginModel user)
        {
            ValidationResult lengthResult = StringValidation.ValidatePhoneNumberLength(user.PhoneNumber);
            ValidationResult inputResult = StringValidation.ValidatePhoneNumberInput(user.PhoneNumber);
            ValidationResult passwordLengthResult = StringValidation.ValidatePasswordLength(user.Password);

            if (!lengthResult.Result)
            {
                // write to log - lengthResult.Description;
                return false;
            }
            if (!inputResult.Result)
            {
                // write to log - inputResult.Description;
                return false;
            }
            if (!passwordLengthResult.Result)
            {
                // write to log - passwordLengthResult.Description;
                return false;
            }
            return true;
        }

        public void Register()
        {

        }

        public CustomerModel GetDetailsForUserById(int id)
        {
            var dbCustomer = URepository.GetCustoemrById(id);
            var convertedCustomer = FromDbToProgram.ConvertCustomer(dbCustomer);
            return convertedCustomer;
        }

        public void UpdateUserDetail()
        {

        }

        public void AddLineToUser()
        {

        }

        public void RemoveLineToUser()
        {

        }

        public void GetListOfPackages()
        {

        }

        public void UpdatePackageForLine()
        {

        }

    }
}
