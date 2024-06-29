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

namespace SeleniteSeaSharp_Editor.controls
{
    /// <summary>
    /// Logika interakcji dla klasy ScriptAction.xaml
    /// </summary>
    public partial class ScriptAction : DisplayAction
    {
        public override Color Color { get => Colors.Wheat; set { _color = value; } }
        public ScriptAction()
        {
            InitializeComponent();
        }
    }
}
