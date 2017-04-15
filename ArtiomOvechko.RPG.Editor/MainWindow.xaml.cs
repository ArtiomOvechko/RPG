using System.Windows;

namespace ArtiomOvechko.RPG.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentPage.Content = new Pages.Editor();
        }
    }
}
