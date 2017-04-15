using System.Windows.Controls;

using Chevo.RPG.ViewModel.Level;
using System.Windows;

namespace ArtiomOvechko.RPG.Editor.Pages
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Page
    {
        public Editor()
        {
            InitializeComponent();
            DataContext = new EditorLevel((int)SystemParameters.VirtualScreenWidth, (int)SystemParameters.VirtualScreenHeight);
        }
    }
}
