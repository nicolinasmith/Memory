using Memory.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Memory.Converters
{
    class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardstatus = (CardStatus)value;
            return cardstatus switch
            {
                CardStatus.CardUp => Visibility.Visible,
                CardStatus.CuteCardDown => Visibility.Collapsed,
                CardStatus.HorrorCardDown => Visibility.Collapsed,
                _ => throw new NotImplementedException(),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
