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
    public partial class CrmManagerView : Window
    {
        private int SessionUserId { get; set; }
        public List<CustomerModel> Customers { get; set; }
        public CrmManagerViewModel ViewModel { get; set; }

        public CrmManagerView(int id)
        {
            InitializeComponent();
            SessionUserId = id;
            ViewModel = new CrmManagerViewModel();
            Customers = new List<CustomerModel>();
            dGrid.ItemsSource = Customers;
        }

        private void RedirectToCreateNewEmployee(object sender, RoutedEventArgs e)
        {
            var newWin = new AddEmployeeView(SessionUserId);
            newWin.Show();
            this.Hide();
        }

        private void RedirectToCreateNewCustomer(object sender, RoutedEventArgs e)
        {
            var newWin = new AddCustomerView(SessionUserId, this);
            newWin.Show();
            this.Hide();
        }

        private void RedirectToBillingSystem(object sender, RoutedEventArgs e)
        {
            var newWin = new BillingSystemView(SessionUserId);
            newWin.Show();
            this.Hide();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            Customers = ViewModel.FindCustomers(tbxSearchUser.Text).ToList();
            dGrid.ItemsSource = Customers;
        }

        private void GetDetailsForSelectedCustomer(object sender, MouseButtonEventArgs e)
        {
            var v = (CustomerModel)dGrid.SelectedItem;
            if (v != null)
            {
                var newWin = new CustomerDetailsView(SessionUserId, v, this);
                newWin.Show();
                this.Hide();
            }
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var newWin = new MainWindow();
            newWin.Show();
            this.Close();
        }
    }
}
