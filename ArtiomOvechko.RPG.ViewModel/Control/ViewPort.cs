using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Common.Helpers;
using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;

using System.ComponentModel;


namespace ArtiomOvechko.RPG.ViewModel.Control
{
    public class ViewPort : IViewPort
    {
        private int _height;
        private int _width;
        private int _xPos;
        private int _yPos;

        public int Height
        {
            get
            {
                return _height;
            }

            private set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }

            private set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        public int XPos
        {
            get
            {
                return _xPos;
            }

            private set
            {
                _xPos = value;
                OnPropertyChanged("XPos");
            }
        }

        public int YPos
        {
            get
            {
                return _yPos;
            }

            private set
            {
                _yPos = value;
                OnPropertyChanged("YPos");
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ViewPort(int width, int height, Point point)
        {
            Width = width;
            Height = height;
            XPos = point.X;
            YPos = point.Y;
        }

        public void Move(Direction direction, int offset)
        {
            switch (direction)
            {
                case Direction.Up:
                    YPos -= offset;
                    return;
                case Direction.Right:
                    XPos -= offset;
                    return;
                case Direction.Down:
                    YPos -= offset;
                    return;
                case Direction.Left:
                    XPos -= offset;
                    return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
