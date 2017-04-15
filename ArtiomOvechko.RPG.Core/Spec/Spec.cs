using ArtiomOvechko.RPG.Core.Interfaces.Instance;

using System.ComponentModel;
using System;

namespace ArtiomOvechko.RPG.Core.Spec
{
    public class Spec: ISpec
    {
        private int _xPos;
        private int _yPos;
        private int _size;
        private int _lives;
        private int _damage;
        private int _stepLength;

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        public int XPos
        {
            get
            {
                return _xPos;
            }

            set
            {
                _xPos = value;
                OnPropertyChanged("XPos");
                OnPropertyChanged("CenteredXPosForDisplay");
            }
        }

        public int YPos
        {
            get
            {
                return _yPos;
            }

            set
            {
                _yPos = value;
                OnPropertyChanged("YPos");
                OnPropertyChanged("CenteredYPosForDisplay");
            }
        }

        public int CenteredXPosForDisplay
        {
            get
            {
                return _xPos - _size / 2;
            }
        }

        public int CenteredYPosForDisplay
        {
            get
            {
                return _yPos - _size / 2;
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Lives
        {
            get
            {
                return _lives > 0 ? _lives : 0;
            }

            set
            {
                _lives = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public int StepLenght
        {
            get
            {
                return _stepLength;
            }

            set
            {
                _stepLength = value;
            }
        }

        public Spec(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public Spec(int xPos, int yPos, string name)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public Spec(int xPos, int yPos, int size)
        {
            XPos = xPos;
            YPos = yPos;
            Size = size;
        }

        public Spec(int xPos, int yPos, int size, string name)
        {
            XPos = xPos;
            YPos = yPos;
            Size = size;
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
