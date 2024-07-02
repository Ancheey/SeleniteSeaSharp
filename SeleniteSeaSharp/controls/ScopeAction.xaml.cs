using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using static SeleniteSeaScript.ScriptRegistry;
using SeleniteSeaScript.Scopes;
using SeleniteSeaScript.Actions;

namespace SeleniteSeaSharp_Editor.controls
{
    /// <summary>
    /// Logika interakcji dla klasy ScopeAction.xaml
    /// </summary>
    public partial class ScopeAction : DisplayAction
    {
        public override Color Color {
            get => _color;
            set
            {
                _color = value;
                PrimaryBorder.Color = value;
                ActionTitle.Foreground = new SolidColorBrush(value);
                Background = new SolidColorBrush(value)
                {
                    Opacity = 0.02
                };
                foreach (var i in ScopeActionsContainer.Children)
                    if (i is ScopeAddButton a)
                        a.Color = value;
            }
        }
        public ScopeAction()
        {
            InitializeComponent();
            var additionbutton = new ScopeAddButton((o, e) => { ClickAddButton(0); });
            ScopeActionsContainer.Children.Add(additionbutton);
        }
        public void AddAction(DisplayAction action, int index)
        {
            ScopeActionsContainer.Children.Insert(index+1, action);
            var additionbutton = new ScopeAddButton((o, e) => { ClickAddButton(index + 2); });
            ScopeActionsContainer.Children.Insert(index+2, additionbutton);
        }
        public void ClickAddButton(int targetindex) => NewActionDialog.ShowDialog((type,desc) => ActionAddition(targetindex,type,desc));
        private void ActionAddition(int targetindex,Type? type, ActionDescriptor? desc) 
        {
            //todo: switch for actions
            //This is badly done, but has to be this way for now
            if (type == null)
                return;
            if(type == typeof(BasicScope))
                AddAction(new ScopeAction(), targetindex);
            if (type == typeof(NewVariableAction))
                AddAction(new ScriptAction(Colors.Blue), targetindex);
        }
    }
}
