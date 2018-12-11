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
    public partial class BillingSystemView : Window
    {
        public BillingSystemView(int sessionUserId)
        {
            InitializeComponent();
            ViewModel = new BillingSystemViewModel();
            PreviouseWindow = new CrmManagerView(sessionUserId);
        }

        private BillingSystemViewModel ViewModel { get; set; }
        private CrmManagerView PreviouseWindow { get; set; }

        private void GenerateCalls(object sender, RoutedEventArgs e)
        {
            if (ViewModel.GenerateCalls())
                MessageBox.Show("Calls generated successfuly");
            else MessageBox.Show("Operation Failed");
        }

        private void GenerateSMSs(object sender, RoutedEventArgs e)
        {
            if (ViewModel.GenerateSMSs())
                MessageBox.Show("SMSs generated successfuly");
            else MessageBox.Show("Operation Failed");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            PreviouseWindow.Show();
            this.Close();
        }
    }
}
