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
    public partial class AddCustomerView : Window
    {
        public AddCustomerView(int id, CrmEmployeeView lastWindow)
        {
            InitializeComponent();
            ViewModel = new AddCustomerViewModel();
            SessionUserId = id;
            PreviousWindow = lastWindow;
        }
        public AddCustomerView(int id, CrmManagerView lastWindow)
        {
            InitializeComponent();
            ViewModel = new AddCustomerViewModel();
            SessionUserId = id;
            PreviousWindow = lastWindow;
        }

        private AddCustomerViewModel ViewModel { get; set; }
        private int SessionUserId { get; set; }
        //private CustomerModel Customer { get; set; }
        private Window PreviousWindow { get; set; }

        private void Next(object sender, RoutedEventArgs e)
        {
            #region
            string fName = tbxFirstName.Text;
            string lName = tbxLastName.Text;
            string password = tbxPassword.Text;
            string phone = tbxPhoneNumber.Text;
            string address = tbxAddress.Text;
            string email = tbxEmailAddress.Text;
            #endregion

            if (ViewModel.ValidateInput(fName, lName, password, phone, address, email))
            {
                //Customer = new CustomerModel
                //{
                //    FirstName = tbxFirstName.Text,
                //    LastName = tbxLastName.Text,
                //    PhoneNumber = tbxPhoneNumber.Text,
                //    Password = tbxPassword.Text,
                //    Address = tbxAddress.Text,
                //    EmailAddress = tbxEmailAddress.Text,
                //    IsActive = true
                //};

                var result = ViewModel.AddCustomer(fName, lName, password, phone, address, email);
                if (result.IsCreated)
                {
                    var nextPage = new AddLineAndPackageView(SessionUserId, result.Id, PreviousWindow);
                    nextPage.Show();
                    this.Close();
                }
                else MessageBox.Show(result.Description);
            }
            else ShowErrorMessages();

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            PreviousWindow.Show();
            this.Close();
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
            errorPassword.Visibility = Visibility.Collapsed;
            errorPhoneNumber.Visibility = Visibility.Collapsed;
            errorAddress.Visibility = Visibility.Collapsed;
            errorEmailAddress.Visibility = Visibility.Collapsed;
        }

    }
}
