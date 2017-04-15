using Chevo.RPG.App.ViewModel;

using System.Windows.Controls;


namespace Chevo.RPG.App.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MainMenu Menu { get; set; }
        public MenuPage()
        {
            InitializeComponent();

            Menu = new MainMenu();

            DataContext = Menu;
        }
    }
}
