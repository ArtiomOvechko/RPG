using Chevo.RPG.ViewModel.Level;
using Chevo.RPG.ViewModel.Helpers;
using Chevo.RPG.Common.Commands;
using Chevo.RPG.App.Models.Interfaces;
using Chevo.RPG.App.Pages;

using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;


namespace Chevo.RPG.App.ViewModel
{
    public class LevelChooseMenu
    {
        private ICommand _joinLevel;
        private ICommand _hostLevel;

        public ICollection<ILevelRepresentationalModel> AvailableLevels
        {
            get
            {
                var availableLevels = new List<Type>();
                var result = new ObservableCollection<ILevelRepresentationalModel>();

                availableLevels.Add(typeof(Sanctuary));

                foreach(var level in availableLevels)
                {
                    result.Add(LevelRepresentationalConverter.GetInstance.ConvertToModel(level));
                }

                return result;
            }
        }

        public ICommand JoinLevel
        {
            get
            {
                if (_joinLevel == null)
                {
                    _joinLevel = new ActionCommand((x) =>
                    {
                        // TODO: conenct to host
                    });
                }
                return _joinLevel;
            }
        }

        public ICommand HostLevel
        {
            get
            {
                if (_hostLevel == null)
                {
                    _hostLevel = new ActionCommand((x) =>
                    {
                        FrameworkElement content = ((MainWindow)App.Current.MainWindow).CurrentPage.Content as FrameworkElement;
                        if (content != null)
                        {
                            var page = new GameLevelPage(new Sanctuary((int)content.ActualWidth, (int)content.ActualHeight));
                            ((MainWindow)App.Current.MainWindow).CurrentPage.Content = page;
                            ((MainWindow)App.Current.MainWindow).KeyUp += page.OnKeyUp;
                            ((MainWindow)App.Current.MainWindow).KeyDown += page.OnKeyDown;
                        }
                    });
                }
                return _hostLevel;
            }
        }
    }
}
