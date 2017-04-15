using System;
using System.Windows.Input;
using System.Collections.Generic;

using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.ViewModel.Interfaces.Level;
using Chevo.RPG.ViewModel.Interfaces;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.ViewModel.Control;
using Chevo.RPG.Common.Commands;

namespace Chevo.RPG.ViewModel.Level
{
    public class EditorLevel: IEditor
    {
        private ICommand _startMove;
        private ICommand _stopMove;

        public int LevelWidth { get; protected set; }
        public int LevelHeight { get; protected set; }

        public IEnumerable<IInstance> LevelObjects { get; protected set; }
        public IEnumerable<IItem> LevelItems { get; protected set; }

        public IViewPort ViewPort { get; protected set; }

        public ICommand StartMove
        {
            get
            {
                if (_startMove == null)
                {
                    _startMove = new ActionCommand((x) =>
                    {
                        //_currentDirection = (Direction)x;
                        //_currentActor.StartMove(_currentDirection);
                    });
                }
                return _startMove;
            }
        }

        public ICommand StopMove
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EditorLevel(int screenWidth, int screenHeight)
        {
            LevelWidth = Common.Settings.GlobalSettings.LevelWidth;
            LevelHeight = Common.Settings.GlobalSettings.LevelHeight;

            /// TODO: Replace it with special editor environment container
            LevelObjects = EnvironmentContainer.Instances;
            LevelItems = EnvironmentContainer.Items;

            ViewPort = new ViewPort(screenWidth, screenHeight);
        }
    }
}
