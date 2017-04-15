using Chevo.RPG.App.Pages;

using System.Windows;

namespace Chevo.RPG.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentPage.Content = new MenuPage();
        }
    }
}
