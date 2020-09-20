using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace ArtiomOvechko.RPG.Desktop.App.Views
{
    public class MainMenu : UserControl
    {
        public void ChooseLevel() 
        {
            LevelManager.Instance.SetLevel(new ChooseLevelMenu());
        }

        public void CreateLevel() 
        {
            LevelManager.Instance.SetLevel(new EditorLevelMenu());
        }

        public MainMenu()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}