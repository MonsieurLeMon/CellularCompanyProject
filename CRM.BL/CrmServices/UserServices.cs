using Common.Models;
using Converters;
using DAL.Db.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace CRM.BL.CrmServices
{
    public class UserServices
    {
        #region Properties And Instances
        private UserRepository Repo { get; set; }
        private ConvertFromDbToProgramModel FromDbToModel { get; set; }
        private ConvertFromProgramToDb FromModelToDb { get; set; }
        private LoginResult Result { get; set; }
        #endregion

        public UserServices()
        {
            Repo = new UserRepository();
            FromDbToModel = new ConvertFromDbToProgramModel();
            FromModelToDb = new ConvertFromProgramToDb();

        }

        public LoginResult LoginEmployee(string username, string password)
        {
            var emp = Repo.GetUserByUsernameAndPassword(username, password);
            if (emp != null)
            {
                return Result = new LoginResult { Id = emp.UserId, Result = true, Emp_Role = emp.Role };
            }
            else
            {
                return Result = new LoginResult { Result = false };
            }
        }
        public bool CreateNewEmployee(EmployeeModel emp)
        {
            var empEntity = ConvertEmployee(emp);
            if (!Repo.IsEmployeeExistByUsername(emp.Username))
                if (Repo.AddUser(empEntity))
                    return true;
            return false;
        }
        public EmployeeModel GetEmployee(int id)
        {
            var emp = Repo.GetEmployeebyId(id);
            var convertedEmp = ConvertEmployee(emp);
            return convertedEmp;
        }




        #region Converts
        private EmployeeModel ConvertEmployee(EmployeeEntity empEntity)
        {
            var empModel = FromDbToModel.ConvertEmployee(empEntity);
            return empModel;
        }

        private EmployeeEntity ConvertEmployee(EmployeeModel empModel)
        {
            var empEntity = FromModelToDb.ConvertEmployee(empModel);
            return empEntity;
        }
        #endregion
    }
}
