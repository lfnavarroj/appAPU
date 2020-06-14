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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        public UserControlMenuItem(MenuItem menuItem)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = menuItem.MenuSubitems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = menuItem.MenuSubitems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = menuItem;
        }
    }
}
