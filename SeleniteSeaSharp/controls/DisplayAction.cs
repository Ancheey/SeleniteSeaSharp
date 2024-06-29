using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeleniteSeaSharp_Editor.controls
{
    public class DisplayAction : UserControl
    {
        protected Color _color;
        public virtual Color Color { get; set; }
        protected DisplayAction() { }
    }
}
