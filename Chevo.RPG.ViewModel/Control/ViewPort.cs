using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.ViewModel.Interfaces.Level;

using System;
using System.ComponentModel;


namespace Chevo.RPG.ViewModel.Control
{
    /// <summary>
    /// Used to move camera
    /// </summary>
    [Serializable]
    public class ViewPort : IViewPort
    {
        private int _screenWidth;
        private int _screenHeight;
        private Point _position;

        public int ScreenWidth
        {
            get
            {
                return _screenWidth;
            }
        }

        public int ScreenHeight
        {
            get
            {
                return _screenHeight;
            }
        }

        /// <summary>
        /// View position relative to level canvas
        /// </summary>
        public Point Position
        {
            get
            {
                return _position;
            }

            private set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }    

        /// <summary>
        /// Create new view attached to player object position
        /// </summary>
        /// <param name="screenWidth">View width</param>
        /// <param name="screenHeight">View height</param>
        /// <param name="target">Player object instance</param>
        public ViewPort(int screenWidth, int screenHeight, IInstance target)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            Position = ScreenCentering.GetInstance.GetCanvasOffset(ScreenCentering.GetInstance.ConvertActorPosition(target.Actor), screenWidth, screenHeight);

            target.Actor.PropertyChanged += ViewPort_PropertyChanged;
        }

        /// <summary>
        /// Create new view that can be moved freely
        /// </summary>
        /// <param name="screenWidth">View width</param>
        /// <param name="screenHeight">View height</param>
        public ViewPort(int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            Position = ScreenCentering.GetInstance.GetCanvasOffset(new Point(screenWidth/2, screenHeight/2), screenWidth, screenHeight);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ViewPort_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Position")
            {
                Position = ScreenCentering.GetInstance.GetCanvasOffset(ScreenCentering.GetInstance.ConvertActorPosition((IActor)sender), _screenWidth, _screenHeight);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
