using System;
using System.Collections.Generic;
using ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces;
using ArtiomOvechko.RPG.Desktop.ViewModel.Level;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtiomOvechko.RPG.Desktop.App.Views
{
    public class ChooseLevelMenu : UserControl
    {
        public List<string> Levels { get; }

        public void HostLevel(string levelName) 
        {
            Tuple<double, double> widthHeight = LevelManager.Instance.GetWindowWidthHeight();
            ILevel level = new Sanctuary((int)widthHeight.Item1, (int)widthHeight.Item2);
            LevelManager.Instance.SetLevel(new GameLevelMenu(level));
        }

        public ChooseLevelMenu()
        {
            Levels = new List<string>() {
                "Sandbox"
            };
            DataContext = this;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}