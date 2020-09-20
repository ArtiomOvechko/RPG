using ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction;

using System.Collections.Generic;
using System.ComponentModel;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;

namespace ArtiomOvechko.RPG.Desktop.ViewModel.Playable
{
    class DefaultPlayableSet : IPlayable, INotifyPropertyChanged
    {
        private IInteractionHandler _interactionHandler;
        private IControl _player;
        private IViewPort _viewPort;
        private ICollection<IInstance> _levelInstances;

        public DefaultPlayableSet(IControl player, IViewPort viewPort, IInteractionHandler interactionHandler, ICollection<IInstance> levelObjects)
        {
            _player = player;
            _viewPort = viewPort;
            _interactionHandler = interactionHandler;
            _levelInstances = levelObjects;
        }

        public ICollection<IInstance> LevelInstances
        {
            get
            {
                return _levelInstances;
            }
            set
            {
                _levelInstances = value;
                OnPropertyChanged("LevelObjects");
            }
        }

        /// <summary>
        /// Player control
        /// </summary>
        public IControl Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                OnPropertyChanged("Player");
            }
        }

        /// <summary>
        /// Interaction handler
        /// </summary>
        public IInteractionHandler InteractionHandler
        {
            get
            {
                return _interactionHandler;
            }
            set
            {
                _interactionHandler = value;
                OnPropertyChanged("Interactor");
            }
        }

        /// <summary>
        /// Camera view port
        /// </summary>
        public IViewPort ViewPort
        {
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
