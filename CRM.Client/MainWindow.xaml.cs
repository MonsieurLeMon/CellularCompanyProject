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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM.Client
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            LoginResult res = ViewModel.LogIn(tbxUsername.Text, tbxPassword.Password);
            if (res.Result)
            {
                ViewModel.RedirectTo(res, this);
            }
            else
            {
                if (!ViewModel.UsernameResult.Result)
                {
                    errorUsername.Content = ViewModel.UsernameResult.Description;
                    errorUsername.Visibility = Visibility.Visible;
                }
                if (!ViewModel.PasswordResult.Result)
                {
                    errorPassword.Content = ViewModel.PasswordResult.Description;
                    errorPassword.Visibility = Visibility.Visible;
                }
                if (ViewModel.PasswordResult.Result && ViewModel.UsernameResult.Result)
                    MessageBox.Show("Username or password incorrect");
            }
        }

        private void tbxTextChanged(object sender, TextChangedEventArgs e)
        {
            CollapseErrorMessages();
        }

        private void tbxTextChanged(object sender, RoutedEventArgs e)
        {
            CollapseErrorMessages();
        }

        private void CollapseErrorMessages()
        {
            errorUsername.Visibility = Visibility.Collapsed;
            errorPassword.Visibility = Visibility.Collapsed;
        }
    }
}
