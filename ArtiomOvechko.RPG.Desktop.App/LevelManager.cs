using System;
using Avalonia.Controls;

namespace ArtiomOvechko.RPG.Desktop.App 
{
    public class LevelManager 
    {
        private static volatile object _lock = new object();
        private static LevelManager _instance;

        private MainWindow _window;

        private LevelManager() { }

        public static LevelManager Instance 
        {
            get 
            {
                if (_instance == null) 
                {
                    lock(_lock) 
                    {
                        if (_instance == null) 
                        {
                            _instance = new LevelManager();
                        }
                    }
                }

                return _instance;
            }
        }

        public void AttachWindow(MainWindow window) 
        {
            _window = window;
        }

        public void SetLevel(UserControl control) 
        {
            _window.CurrentControl = control;
        }

        public Tuple<double, double> GetWindowWidthHeight() 
        {
            return new Tuple<double, double>(_window.Width, _window.Height);
        }
    }
}