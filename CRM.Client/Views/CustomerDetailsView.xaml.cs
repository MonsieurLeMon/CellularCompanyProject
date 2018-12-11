using Common.Models;
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
    public partial class CustomerDetailsView : Window
    {
        private CustomerModel Customer { get; set; }
        private Window PreviousWindow { get; set; }
        private int SessionUserId { get; set; }

        public CustomerDetailsView(int id, CustomerModel customer, CrmEmployeeView view)
        {
            InitializeComponent();
            SessionUserId = id;
            Customer = customer;
            PreviousWindow = view;
        }

        public CustomerDetailsView(int id, CustomerModel customer, CrmManagerView view)
        {
            InitializeComponent();
            SessionUserId = id;
            Customer = customer;
            PreviousWindow = view;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void AddLine(object sender, RoutedEventArgs e)
        {
            var newWin = new AddLineAndPackageView(SessionUserId, Customer.UserId, this);
            newWin.Show();
            this.Hide();
        }

        private void ChangePackage(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWindow()
        {
            PreviousWindow.Show();
            this.Close();
        }
    }
}
