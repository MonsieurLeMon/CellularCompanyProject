using Common.Enums;
using Common.Models;
using CRM.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM.Client.Views
{
    public partial class AddEmployeeView : Window
    {
        public AddEmployeeView(int id)
        {
            InitializeComponent();
            ViewModel = new AddEmployeeViewModel();
            SessionUserId = id;
        }

        private AddEmployeeViewModel ViewModel { get; set; }
        private int SessionUserId { get; set; }

        #region Events
        private void Submit(object sender, RoutedEventArgs e)
        {
            #region 
            string fName = tbxFirstName.Text;
            string lName = tbxLastName.Text;
            string uName = tbxUsername.Text;
            string password = tbxPassword.Text;
            string phone = tbxPhoneNumber.Text;
            string address = tbxAddress.Text;
            string email = tbxEmailAddress.Text;
            EmployeeRole role = CheckRole();
            #endregion

            if (ViewModel.ValidateInput(fName, lName, uName, password, phone, address, email))
                if (ViewModel.CreateNewEmployee(fName, lName, uName, password, phone, address, email, role))
                {
                    MessageBox.Show("User Created");
                    GoToPreviousWindow();
                }
                else MessageBox.Show("Could not add employee successfully, try with diffreren username");
            ShowErrorMessages();
        }

        private EmployeeRole CheckRole()
        {
            if (cbxIsManager.IsChecked == true)
                return EmployeeRole.Manager;
            else return EmployeeRole.CustomerService;
        }

        private void ShowErrorMessages()
        {
            if (!ViewModel.FNameValidation.Result)
            {
                errorFirstName.Content = ViewModel.FNameValidation.Description;
                errorFirstName.Visibility = Visibility.Visible;
            }
            if (!ViewModel.LNameValidation.Result)
            {
                errorLastName.Content = ViewModel.LNameValidation.Description;
                errorLastName.Visibility = Visibility.Visible;
            }
            if (!ViewModel.UNameValidation.Result)
            {
                errorUsername.Content = ViewModel.UNameValidation.Description;
                errorUsername.Visibility = Visibility.Visible;
            }
            if (!ViewModel.PhoneInputValidation.Result)
            {
                errorPhoneNumber.Content = ViewModel.PhoneInputValidation.Description;
                errorPhoneNumber.Visibility = Visibility.Visible;
            }
            if (!ViewModel.PhoneLengthValidation.Result)
            {
                errorPhoneNumber.Content = ViewModel.PhoneLengthValidation.Description;
                errorPhoneNumber.Visibility = Visibility.Visible;
            }
            if (!ViewModel.PasswordValidation.Result)
            {
                errorPassword.Content = ViewModel.PasswordValidation.Description;
                errorPassword.Visibility = Visibility.Visible;
            }
            if (!ViewModel.AddressValidation.Result)
            {
                errorAddress.Content = ViewModel.AddressValidation.Description;
                errorAddress.Visibility = Visibility.Visible;
            }
            if (!ViewModel.EmailAddressValidation.Result)
            {
                errorEmailAddress.Content = ViewModel.EmailAddressValidation.Description;
                errorEmailAddress.Visibility = Visibility.Visible;
            }
        }

        private void CollapseErrorMessages(object sender, TextChangedEventArgs e)
        {
            errorFirstName.Visibility = Visibility.Collapsed;
            errorLastName.Visibility = Visibility.Collapsed;
            errorUsername.Visibility = Visibility.Collapsed;
            errorPassword.Visibility = Visibility.Collapsed;
            errorPhoneNumber.Visibility = Visibility.Collapsed;
            errorAddress.Visibility = Visibility.Collapsed;
            errorEmailAddress.Visibility = Visibility.Collapsed;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GoToPreviousWindow();
        }

        private void GoToPreviousWindow()
        {
            var newWin = new CrmManagerView(SessionUserId);
            newWin.Show();
            this.Close();
        }
        #endregion
    }
}