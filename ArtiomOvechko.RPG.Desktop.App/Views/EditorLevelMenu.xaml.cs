using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtiomOvechko.RPG.Desktop.App.Views
{
    public class EditorLevelMenu : UserControl
    {
        public EditorLevelMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}