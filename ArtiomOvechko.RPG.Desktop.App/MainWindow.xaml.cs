using System.ComponentModel;
using System.Runtime.CompilerServices;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using ArtiomOvechko.RPG.Desktop.App.Views;


namespace ArtiomOvechko.RPG.Desktop.App
{
    public class MainWindow : Window, INotifyPropertyChanged
    {
        private UserControl _currentLevel;
        public UserControl CurrentControl 
        {
            get => _currentLevel;
            set {
                _currentLevel = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            LevelManager.Instance.AttachWindow(this);
            LevelManager.Instance.SetLevel(new MainMenu());
        }

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}