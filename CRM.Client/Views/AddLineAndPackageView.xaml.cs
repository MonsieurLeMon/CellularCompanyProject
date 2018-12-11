using Common.Models;
using CRM.BL.CrmServices;
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
    public partial class AddLineAndPackageView : Window
    {
        public AddLineAndPackageView(int sessionUserId, int customerId, Window window)
        {
            InitializeComponent();
            ViewModel = new AddLineAndPackageViewModel();
            CustomerId = customerId;
            SessionUserId = sessionUserId;
            PreviouseWindow = window;

        }
        public AddLineAndPackageView(int sessionUserId, int customerId, CrmEmployeeView window)
        {
            InitializeComponent();
            ViewModel = new AddLineAndPackageViewModel();
            CustomerId = customerId;
            SessionUserId = sessionUserId;
            PreviouseWindow = window;

        }
        public AddLineAndPackageView(int sessionUserId, int customerId, CrmManagerView window)
        {
            InitializeComponent();
            ViewModel = new AddLineAndPackageViewModel();
            CustomerId = customerId;
            SessionUserId = sessionUserId;
            PreviouseWindow = window;
        }

        private int SessionUserId { get; set; }
        private int CustomerId { get; set; }
        private Window PreviouseWindow { get; set; }
        private AddLineAndPackageViewModel ViewModel { get; set; }

        private void Save(object sender, RoutedEventArgs e)
        {
            string lineNumber = tbxLineNumber.Text;
            var result = ViewModel.AddLine(lineNumber, CustomerId);

            if (result.IsCreated == false)
            {
                MessageBox.Show(result.Description);
            }
            else
            {
                #region
                int lineId = result.Id;
                string pName = tbxPackageName.Text;
                double baseMinPrice = double.Parse(tbxBaseMinutePrice.Text);
                double baseSMSPrice = double.Parse(tbxBaseSMSPrice.Text);
                #endregion

                if (rbtnMinutes.IsChecked == true)
                {
                    double bankPrice = double.Parse(tbxMinuteBankPrice.Text);
                    int amountOfMins = int.Parse(tbxMinutesAmount.Text);
                    int amountOfSMS = int.Parse(tbxSMSAmount.Text);
                    ViewModel.AddPackageToLine(lineId, pName, baseMinPrice, baseSMSPrice, bankPrice, amountOfMins, amountOfSMS);
                    MessageBox.Show("Success!");
                    CloseWindow();
                }
                else if (rbtnSpecial.IsChecked == true)
                {
                    double specialMinPrice = double.Parse(tbxSpecialMinutePrice.Text);
                    double specialSMSPrice = double.Parse(tbxSpecialSMSPrice.Text);
                    ViewModel.AddPackageToLine(lineId, pName, baseMinPrice, baseSMSPrice, specialMinPrice, specialSMSPrice);
                    MessageBox.Show("Success!");
                    CloseWindow();
                }
                else
                {
                    errorPackageType.Content = "Package type not selected";
                    errorPackageType.Visibility = Visibility.Visible;
                }
            }
        }

        private void MinutesBankSelected(object sender, RoutedEventArgs e)
        {
            errorPackageType.Visibility = Visibility.Collapsed;
            ShowMinuteBankFields();
        }

        private void SpecialPriceSelected(object sender, RoutedEventArgs e)
        {
            errorPackageType.Visibility = Visibility.Collapsed;
            ShowSpecialPriceFields();
        }

        private void ShowMinuteBankFields()
        {
            #region Show
            lblMinuteBankPrice.Visibility = Visibility.Visible;
            tbxMinuteBankPrice.Visibility = Visibility.Visible;
            errorMinuteBankPrice.Visibility = Visibility.Collapsed;

            lblMinutesAmount.Visibility = Visibility.Visible;
            tbxMinutesAmount.Visibility = Visibility.Visible;
            errorMinutesAmount.Visibility = Visibility.Collapsed;

            lblSMSAmount.Visibility = Visibility.Visible;
            tbxSMSAmount.Visibility = Visibility.Visible;
            errorSMSAmount.Visibility = Visibility.Collapsed;
            #endregion

            #region Collapse
            lblSpecialMinutePrice.Visibility = Visibility.Collapsed;
            tbxSpecialMinutePrice.Visibility = Visibility.Collapsed;
            errorSpecialMinutePrice.Visibility = Visibility.Collapsed;

            lblSpecialSMSPrice.Visibility = Visibility.Collapsed;
            tbxSpecialSMSPrice.Visibility = Visibility.Collapsed;
            errorSpecialSMSPrice.Visibility = Visibility.Collapsed;
            #endregion
        }

        private void ShowSpecialPriceFields()
        {
            #region Show
            lblSpecialMinutePrice.Visibility = Visibility.Visible;
            tbxSpecialMinutePrice.Visibility = Visibility.Visible;
            errorSpecialMinutePrice.Visibility = Visibility.Collapsed;

            lblSpecialSMSPrice.Visibility = Visibility.Visible;
            tbxSpecialSMSPrice.Visibility = Visibility.Visible;
            errorSpecialSMSPrice.Visibility = Visibility.Collapsed;
            #endregion

            #region Collapsed
            lblMinuteBankPrice.Visibility = Visibility.Collapsed;
            tbxMinuteBankPrice.Visibility = Visibility.Collapsed;
            errorMinuteBankPrice.Visibility = Visibility.Collapsed;

            lblMinutesAmount.Visibility = Visibility.Collapsed;
            tbxMinutesAmount.Visibility = Visibility.Collapsed;
            errorMinutesAmount.Visibility = Visibility.Collapsed;

            lblSMSAmount.Visibility = Visibility.Collapsed;
            tbxSMSAmount.Visibility = Visibility.Collapsed;
            errorSMSAmount.Visibility = Visibility.Collapsed;
            #endregion
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {

            PreviouseWindow.Show();
            this.Close();
        }
    }
}
