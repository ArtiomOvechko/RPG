using Chevo.RPG.App.ViewModel;

using System.Windows.Controls;


namespace Chevo.RPG.App.Pages
{
    /// <summary>
    /// Interaction logic for AvailableLevelsPage.xaml
    /// </summary>
    public partial class AvailableLevelsPage : Page
    {
        public LevelChooseMenu Menu { get; set; }
        public AvailableLevelsPage()
        {
            InitializeComponent();

            Menu = new LevelChooseMenu();

            DataContext = Menu;
        }
    }
}
