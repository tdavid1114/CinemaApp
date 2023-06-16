using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CinemaApp.Converters
{
    public class SeatColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int status = (int)value;
            if (status == 0)
            {
                return new SolidColorBrush(Color.FromRgb(48, 105, 86));
            }
            else if (status == 1)
            {
                return Brushes.White;
            }

            return new SolidColorBrush(Color.FromRgb(211, 35, 61));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}