using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Memory.Enums;

namespace Memory.Converters
{
    class CardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardstatus = (CardStatus)value;

            switch (cardstatus)
            {
                case CardStatus.CuteCardDown:
                    var imageBrush = new ImageBrush();
                    var imageUri = new Uri("pack://application:,,,/Memory_G7;component/Pictures/Rainbow.jpg");
                    imageBrush.ImageSource = new BitmapImage(imageUri);
                    return imageBrush;

                case CardStatus.HorrorCardDown:
                    var fruitImageBrush = new ImageBrush();
                    var fruitImageUri = new Uri("pack://application:,,,/Memory_G7;component/Pictures/Clouds.jpg");
                    fruitImageBrush.ImageSource = new BitmapImage(fruitImageUri);
                    return fruitImageBrush;

                case CardStatus.CardUp:
                    return new SolidColorBrush(Colors.Transparent);


                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
