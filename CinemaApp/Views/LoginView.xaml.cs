using GalaSoft.MvvmLight.Messaging;
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

namespace CinemaApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private int x = 0;

        public LoginView()
        {
            InitializeComponent();
            Messenger.Default.Register<bool>(this, "login", msg =>
            {
                registerPanel.Visibility = Visibility.Collapsed;
                loginPanel.Visibility = Visibility.Visible;
            });
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            registerPanel.Visibility = Visibility.Visible;
            loginPanel.Visibility = Visibility.Collapsed;
        }
    }
}