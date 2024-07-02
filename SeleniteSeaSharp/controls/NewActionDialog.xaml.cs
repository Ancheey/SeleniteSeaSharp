using SeleniteSeaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static SeleniteSeaScript.ScriptRegistry;

namespace SeleniteSeaSharp_Editor.controls
{
    /// <summary>
    /// Logika interakcji dla klasy NewActionDialog.xaml
    /// </summary>
    public partial class NewActionDialog : Window
    {
        protected (Type? type, ActionDescriptor? desc) Result = (null,null);
        private bool isclosing = false;
        NewActionDialog()
        {
            
            InitializeComponent();
            Deactivated += (o, e) =>
            {
                if (!isclosing)
                {
                    Result = (null, null);
                    Close();
                }
            };
            foreach(var sc in ScriptRegistry.Scopes)
            {
                var item = new ListBoxItem()
                {
                    Foreground = new SolidColorBrush(Colors.Yellow),
                    Content = sc.Value.DisplayName
                };
                item.MouseDoubleClick += (o, e) => { Result = (sc.Key, sc.Value); isclosing = true; Close(); };
                ActionSelectionListbox.Items.Add(item);
            }
            foreach (var sc in ScriptRegistry.Actions)
            {
                var item = new ListBoxItem()
                {
                    Foreground = new SolidColorBrush(Colors.Blue),
                    Content = sc.Value.DisplayName
                };
                item.MouseDoubleClick += (o, e) => { Result = (sc.Key, sc.Value); isclosing = true; Close(); };
                ActionSelectionListbox.Items.Add(item);
            }

        }
        /// <summary>
        /// Creates a new window and executes an action upon its closing
        /// This window closes when loosing focus (Deactivation)
        /// Takes in an Action that takes in an int result which is the ID of the picked action
        /// </summary>
        /// <param name="ExecuteUponFinishing">int result as param</param>
        public static void ShowDialog(Action<Type?, ActionDescriptor?> ExecuteUponFinishing)
        {
            var win = new NewActionDialog();
            win.Show();
            win.Focus();
            win.Closing += (o, e) =>
            {
                ExecuteUponFinishing(win.Result.type, win.Result.desc);
            };
        }
    }
}
