using Castle.Components.DictionaryAdapter;
using CinemaApp.Models;
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
    /// Interaction logic for MoviesView.xaml
    /// </summary>
    public partial class MoviesView : UserControl
    {
        private string selectedDay;

        public MoviesView()
        {
            InitializeComponent();
            todayImage.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.DayOfWeek.ToString() + "Hover.png", UriKind.Relative));
            todayImage1.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(1).DayOfWeek.ToString() + ".png", UriKind.Relative));
            todayImage2.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(2).DayOfWeek.ToString() + ".png", UriKind.Relative));
            todayImage3.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(3).DayOfWeek.ToString() + ".png", UriKind.Relative));
            todayImage4.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(4).DayOfWeek.ToString() + ".png", UriKind.Relative));
            todayImage5.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(5).DayOfWeek.ToString() + ".png", UriKind.Relative));
            todayImage6.Source = new BitmapImage(new Uri("/Icons/" + DateTime.Today.AddDays(6).DayOfWeek.ToString() + ".png", UriKind.Relative));
            selectedDay = DateTime.Today.DayOfWeek.ToString() + "Hover";
        }

        private void Day_MouseEnter(object sender, MouseEventArgs e)
        {
            string daySource = (e.Source as Image).Source.ToString();
            string day = daySource.Substring(daySource.LastIndexOf("/") + 1, daySource.LastIndexOf(".") - (daySource.LastIndexOf("/") + 1));
            if (!day.Contains("Hover"))
            {
                (e.Source as Image).Source = new BitmapImage(new Uri("/Icons/" + day + "Hover.png", UriKind.Relative));
            }
        }

        private void Day_MouseLeave(object sender, MouseEventArgs e)
        {
            string daySource = (e.Source as Image).Source.ToString();
            string day = daySource.Substring(daySource.LastIndexOf("/") + 1, daySource.LastIndexOf(".") - (daySource.LastIndexOf("/") + 1));
            if (day != selectedDay)
            {
                (e.Source as Image).Source = new BitmapImage(new Uri("/Icons/" + day.Substring(0, day.Length - 5) + ".png", UriKind.Relative));
            }
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string daySource = (e.Source as Image).Source.ToString();
            string day = daySource.Substring(daySource.LastIndexOf("/") + 1, daySource.LastIndexOf(".") - (daySource.LastIndexOf("/") + 1));

            if (selectedDay != day)
            {
                for (int i = 0; i < (sender as StackPanel).Children.Count; i++)
                {
                    string daySource2 = ((sender as StackPanel).Children[i] as Image).Source.ToString();
                    string day2 = daySource2.Substring(daySource2.LastIndexOf("/") + 1, daySource2.LastIndexOf(".") - (daySource2.LastIndexOf("/") + 1));
                    if (day2 == selectedDay)
                    {
                        ((sender as StackPanel).Children[i] as Image).Source = new BitmapImage(new Uri("/Icons/" + day2.Substring(0, day2.Length - 5) + ".png", UriKind.Relative));
                    }
                }
                selectedDay = day;
            }
        }
    }
}