using Common.Models;
using Common.Validations;
using Common.Enums;
using CRM.BL.CrmServices;
using System.Windows;
using CRM.Client.Views;

namespace CRM.Client.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Services = new UserServices();
            Validate = new ValidateStringInput();
        }

        #region Login
        public ValidationResult UsernameResult { get; set; }
        public ValidationResult PasswordResult { get; set; }
        public LoginResult Result { get; set; }
        private UserServices Services { get; set; }
        private ValidateStringInput Validate { get; set; }

        public LoginResult LogIn(string usernameInput, string passwordInput)
        {
            UsernameResult = Validate.ValidateUsernameLength(usernameInput);
            PasswordResult = Validate.ValidatePasswordLength(passwordInput);

            if (UsernameResult.Result && PasswordResult.Result)
                return Result = Services.LoginEmployee(usernameInput, passwordInput);
            else
                return Result = new LoginResult { Result = false };

        }
        #endregion

        #region RedirectTo
        private Window NewView { get; set; }

        public void RedirectTo(LoginResult res, Window win)
        {
            switch (res.Emp_Role)
            {
                case EmployeeRole.CustomerService:
                    NewView = new CrmEmployeeView(res.Id);
                    break;
                case EmployeeRole.Manager:
                    NewView = new CrmManagerView(res.Id);
                    break;
            }
            NewView.Show();
            win.Close();
        }
        #endregion
    }
}
