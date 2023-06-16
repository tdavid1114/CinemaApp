using CinemaApp.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for NavBarView.xaml
    /// </summary>
    public partial class NavBarView : UserControl
    {
        public NavBarView()
        {
            InitializeComponent();
            Messenger.Default.Register<bool>(this, "logstatus", msg =>
            {
                if (msg)
                {
                    SeatsViewModel.loggedIn = true;
                    loginMenuButton.Visibility = Visibility.Collapsed;
                    logoutMenuButton.Visibility = Visibility.Visible;
                    //accountMenuButton.Visibility = Visibility.Visible;
                    ticketsMenuButton.Visibility = Visibility.Visible;
                }
                else
                {
                    SeatsViewModel.loggedIn = false;
                    loginMenuButton.Visibility = Visibility.Visible;
                    logoutMenuButton.Visibility = Visibility.Collapsed;
                    accountMenuButton.Visibility = Visibility.Collapsed;
                    ticketsMenuButton.Visibility = Visibility.Collapsed;
                }
            });
        }

        private void Movie_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("movieImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/movieHover.png", UriKind.Relative));
        }

        private void Movie_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("movieImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/movie.png", UriKind.Relative));
        }

        private void Ticket_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("ticketImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/ticketHover.png", UriKind.Relative));
        }

        private void Ticket_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("ticketImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/ticket.png", UriKind.Relative));
        }

        private void Account_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("accountImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/accountHover.png", UriKind.Relative));
        }

        private void Account_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("accountImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/account.png", UriKind.Relative));
        }

        private void Login_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("loginImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/loginHover.png", UriKind.Relative));
        }

        private void Login_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("loginImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/login.png", UriKind.Relative));
        }

        private void Logout_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("logoutImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/logoutHover.png", UriKind.Relative));
        }

        private void Logout_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = ((Button)sender).FindName("logoutImage") as Image;
            image.Source = new BitmapImage(new Uri("/Icons/logout.png", UriKind.Relative));
        }
    }
}