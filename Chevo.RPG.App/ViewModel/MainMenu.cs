using System.Windows.Input;

using Chevo.RPG.Common.Commands;
using Chevo.RPG.App.Pages;

namespace Chevo.RPG.App.ViewModel
{
    public class MainMenu 
    {
        private ICommand _viewLevels;

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
    }
}
