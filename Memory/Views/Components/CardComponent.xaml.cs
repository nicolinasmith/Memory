using Memory.Enums;
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

namespace Memory.Views.Components
{
    /// <summary>
    /// Interaction logic for CardComponent.xaml
    /// </summary>
    public partial class CardComponent : UserControl
    {
        public CardComponent()
        {
            InitializeComponent();
        }

        public int Id { get; set; }

        public Uri Picture
        {
            get { return (Uri)GetValue(PictureProperty); }
            set { SetValue(PictureProperty, value); }
        }

        public static readonly DependencyProperty PictureProperty =
            DependencyProperty.Register("Picture", typeof(Uri), typeof(CardComponent), new PropertyMetadata(new Uri("pack://application:,,,/Memory;component/Images/Cute/Bunny.jpg")));


        public CardStatus CardStatus
        {
            get { return (CardStatus)GetValue(CardStatusProperty); }
            set { SetValue(CardStatusProperty, value); }
        }

        public static readonly DependencyProperty CardStatusProperty =
            DependencyProperty.Register("CardStatus", typeof(CardStatus), typeof(CardComponent), new PropertyMetadata(CardStatus.CuteCardDown));

    }
}
