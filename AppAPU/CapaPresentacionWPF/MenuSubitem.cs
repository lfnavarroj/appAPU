using System.Windows.Controls;

namespace CapaPresentacionWPF
{
    public class MenuSubitem
    {
        public MenuSubitem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
    }
}