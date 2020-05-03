using ArtiomOvechko.RPG.Mono.Core.Stats;
using System.ComponentModel;


namespace ArtiomOvechko.RPG.Mono.Core.Factories
{
    public abstract class BaseInstancePrototype: INotifyPropertyChanged
    {
        private Point _currentPosition;

        public Point Position
        {
            get
            {
                return _currentPosition;
            }

            set
            {
                _currentPosition = value;
                OnPropertyChanged("Position");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
