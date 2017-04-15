using ArtiomOvechko.RPG.Common.Commands;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;


namespace ArtiomOvechko.RPG.ViewModel.Level
{
    public class BaseOfflineLevel: ILevel, INotifyPropertyChanged
    {
        private ICommand _startMove;
        private ICommand _stopMove;
        private ICommand _tryInteract;
        private ICommand _attack;

        private IViewPort _viewPort;

        public IControl Player { get; protected set; }
        public IInteractionHandler Interactor { get; protected set; }
        public IViewPort ViewPort {
            get
            {
                return _viewPort;
            }
            set
            {
                _viewPort = value;
                OnPropertyChanged("ViewPort");
            }
        }
        public ICollection<IInstance> LevelObjects { get; protected set; }

        public ICommand StartMove
        {
            get
            {
                if (_startMove == null)
                {
                    _startMove = new ActionCommand((x) =>
                    {
                        Player.StartMove.Execute(x);
                    });
                }
                return _startMove;
            }
        }

        public ICommand StopMove
        {
            get
            {
                if (_stopMove == null)
                {
                    _stopMove = new ActionCommand((x) =>
                    {
                        Player.StopMove.Execute(x);
                    });
                }
                return _stopMove;
            }
        }

        public ICommand TryInteract
        {
            get
            {
                if (_tryInteract == null)
                {
                    _tryInteract = new ActionCommand((x) =>
                    {
                        Player.TryInteract.Execute(x);
                    });
                }
                return _tryInteract;
            }
        }

        public ICommand Attack
        {
            get
            {
                if (_attack == null)
                {
                    _attack = new ActionCommand((x) =>
                    {
                        Player.Attack.Execute(x);
                    });
                }
                return _attack;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
