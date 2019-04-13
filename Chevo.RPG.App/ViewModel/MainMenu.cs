using System.Windows.Input;

using Chevo.RPG.Common.Commands;
using Chevo.RPG.App.Pages;
using System.Windows;
using Chevo.RPG.ViewModel.Level;

namespace Chevo.RPG.App.ViewModel
{
    public class MainMenu 
    {
        private ICommand _viewLevels;

        private ICommand _createLevel;

        public ICommand ViewLevels
        {
            get
            {
                if (_viewLevels == null)
                {
                    _viewLevels = new ActionCommand((x) =>
                    {
                        ((MainWindow)App.Current.MainWindow).CurrentPage.Content = new AvailableLevelsPage();
                    });
                }

                return _viewLevels;
            }
        }

        public ICommand CreateLevel
        {
            get
            {
                if (_createLevel == null)
                {
                    _createLevel = new ActionCommand((x) =>
                    {
                        FrameworkElement content = ((MainWindow)App.Current.MainWindow).CurrentPage.Content as FrameworkElement;
                        if (content != null)
                        {
                            var page = new EditorLevelPage(new EditorLevel((int)content.ActualWidth, (int)content.ActualHeight));
                            ((MainWindow)App.Current.MainWindow).CurrentPage.Content = page;
                            ((MainWindow)App.Current.MainWindow).KeyUp += page.OnKeyUp;
                            ((MainWindow)App.Current.MainWindow).KeyDown += page.OnKeyDown;
                        }
                    });
                }

                return _createLevel;
            }
        }
    }
}
