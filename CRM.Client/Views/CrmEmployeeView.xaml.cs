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
    public partial class CrmEmployeeView : Window
    {
        public CrmEmployeeView(int id)
        {
            InitializeComponent();
            ViewModel = new CrmEmployeeViewModel();
            Customers = new List<CustomerModel>();
            SessionUserId = id;
            dGrid.ItemsSource = Customers;
        }

        private CrmEmployeeViewModel ViewModel { get; set; }
        private EmployeeModel Employee { get; set; }
        private List<CustomerModel> Customers { get; set; }
        private int SessionUserId { get; set; }

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

        private void RedirectToCreateNewCustomer(object sender, RoutedEventArgs e)
        {
            var newWin = new AddCustomerView(SessionUserId, this);
            newWin.Show();
            this.Hide();
        }


        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

    }
}
