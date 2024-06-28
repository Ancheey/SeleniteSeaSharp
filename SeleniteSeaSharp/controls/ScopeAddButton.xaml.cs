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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeleniteSeaSharp_Editor.controls
{
    /// <summary>
    /// Logika interakcji dla klasy ScopeAddButton.xaml
    /// </summary>
    public partial class ScopeAddButton : UserControl
    {
        private Color _AnimTargetColor = Colors.Yellow;
        public Color Color 
        { 
            get {
                return TailColor.Color;
            }
            set
            {
                Diamond.BorderBrush = new SolidColorBrush(value);
                TailColor.Color = Color;
                Plus.Foreground = new SolidColorBrush(value);
                _AnimTargetColor = value;
            }
        }
        public ScopeAddButton(MouseButtonEventHandler OnClickEvent)
        {
            InitializeComponent();
            Hitbox.MouseLeftButtonUp += OnClickEvent;
            Diamond.Background = new SolidColorBrush(Colors.Transparent);
        }
        public ScopeAddButton()
        {
            InitializeComponent();
            Diamond.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Hitbox_MouseEnter(object sender, MouseEventArgs e)
        {
            ColorAnimation anim = new()
            {
                From = Colors.Transparent,
                To = _AnimTargetColor,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            Diamond.Background.BeginAnimation(SolidColorBrush.ColorProperty, anim);
        }

        private void Hitbox_MouseLeave(object sender, MouseEventArgs e)
        {
            ColorAnimation anim = new()
            {
                To = Colors.Transparent,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            Diamond.Background.BeginAnimation(SolidColorBrush.ColorProperty, anim);
        }
    }
}
