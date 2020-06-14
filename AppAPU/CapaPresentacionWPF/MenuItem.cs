using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CapaPresentacionWPF
{
    public class MenuItem
    {
        public MenuItem(string header, List<MenuSubitem> menuSubitems, PackIconKind icon)
        {
            Header = header;
            MenuSubitems = menuSubitems;
            Icon = icon;
        }

        public MenuItem(string header, UserControl screen, PackIconKind icon)
        {
            Header = header;
            Screen = screen;
            Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<MenuSubitem> MenuSubitems { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
