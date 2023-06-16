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

namespace CinemaApp.Components
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindableConfirmPasswordBox : UserControl
    {
        public static readonly DependencyProperty ConfirmPasswordProperty = DependencyProperty.Register("ConfirmPassword", typeof(string), typeof(BindableConfirmPasswordBox), new PropertyMetadata(string.Empty));

        public string ConfirmPassword
        {
            get { return (string)GetValue(ConfirmPasswordProperty); }
            set { SetValue(ConfirmPasswordProperty, value); }
        }

        public BindableConfirmPasswordBox()
        {
            InitializeComponent();
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ConfirmPassword = confirmPasswordBox.Password;
        }
    }
}