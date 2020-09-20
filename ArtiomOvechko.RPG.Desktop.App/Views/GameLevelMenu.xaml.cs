using System.Threading;
using ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtiomOvechko.RPG.Desktop.App.Views
{
    public class GameLevelMenu : UserControl
    {
        public GameLevelMenu() { }

        public GameLevelMenu(ILevel level)
        {
            DataContext = level;
            ThreadStart ts = new ThreadStart(() =>
            {
                level.Container.Run();
            }); 
            ts.Invoke();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}