using System;
using System.Windows.Input;
using System.Collections.Generic;

using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Mono.ViewModel.Interfaces;
using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.ViewModel.Control;
using ArtiomOvechko.RPG.Mono.Common.Commands;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Actor;
using ArtiomOvechko.RPG.Mono.Core.Behavior.StaticObject;
using System.Linq;
using System.Collections.ObjectModel;
using ArtiomOvechko.RPG.WebApp.Core.Collections;
using ArtiomOvechko.RPG.Mono.Core.Factories;

namespace ArtiomOvechko.RPG.Mono.ViewModel.Level
{
    public class EditorLevel : IEditorLevel
    {
        private ICommand _startMove;
        private ICommand _stopMove;
        private ICommand _pickObject;
        private ICommand _putObject;
        private ICommand _discardObject;
        private ICommand _movePickedObject;
        private IEnvironmentContainer _environment;

        public IInstancePrototype ActivePrototype { get; set; }

        public IEnumerable<IInstancePrototype> ActivePrototypes { get; set; }

        public  IControl Player { get; protected set; }

        public int LevelWidth { get; protected set; }
        public int LevelHeight { get; protected set; }

        // We need to add a container for levelobjects but not included into EnvironmentContainer
        public ViewModelCollection<IInstance> LevelObjects { get; protected set; }

        public ViewModelCollection<IItem> LevelItems { get; protected set; }

        public IEnumerable<IInstancePrototype> PickableObjects { get; protected set; }

        public IViewPort ViewPort { get; protected set; }

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

        public ICommand MovePickedObject
        {
            get
            {
                if (_movePickedObject == null)
                {
                    _movePickedObject = new ActionCommand((x) =>
                    {
                        if (ActivePrototype != null)
                        {
                            ActivePrototype.Position = (Point)x;
                        }
                        
                    });
                }
                return _movePickedObject;
            }
        }

        public ICommand PickObject
        {
            get
            {
                if (_pickObject == null)
                {
                    _pickObject = new ActionCommand((x) =>
                    {
                        ActivePrototype = (IInstancePrototype)x;
                        ((ObservableCollection<IInstancePrototype>)ActivePrototypes).Clear();
                        ((ObservableCollection<IInstancePrototype>)ActivePrototypes).Insert(0, ActivePrototype);
                    });
                }
                return _pickObject;
            }
        }

        public ICommand PutObject
        {
            get
            {
                if (_putObject == null)
                {
                    _putObject = new ActionCommand((x) =>
                    {
                        if (ActivePrototype != null)
                        {
                            LevelObjects.Add( ActivePrototype.CreateInstance((Point)x, _environment));                            
                        }
                    });
                }
                return _putObject;
            }
        }

        public ICommand DiscardObject
        {
            get
            {
                if (_discardObject == null)
                {
                    _discardObject = new ActionCommand((x) =>
                    {
                        ActivePrototype = null;
                    });
                }
                return _discardObject;
            }
        }

        public EditorLevel(int screenWidth, int screenHeight)
        {
            _environment = new EnvironmentContainer();
            
            LevelWidth = Common.Settings.GlobalSettings.LevelWidth;
            LevelHeight = Common.Settings.GlobalSettings.LevelHeight;

            PickableObjects = new ObservableCollection<IInstancePrototype>();
            ActivePrototypes = new ObservableCollection<IInstancePrototype>();
            ((ObservableCollection<IInstancePrototype>)ActivePrototypes).Insert(0, ActivePrototype);

            ///// TODO: Replace it with special editor environment container
            LevelObjects = new ViewModelCollection<IInstance>();          
            //LevelItems = EnvironmentContainer.Items;
            // Add Terrain 4 test
            var wall1 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2400, 2600), _environment));
            var wall2 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2900, 2900), _environment));
            LevelObjects.Add(wall1);
            LevelObjects.Add(wall2);


            //Replace with invisible actor with ignoring collision resolver
            Player = new Player(new BrokenHeart(new Point(2700, 2700), _environment), null);
            ViewPort = new ViewPort(screenWidth, screenHeight, (IInstance)Player);


            // Load available pickable objects
            foreach(Type t in System.Reflection.Assembly.GetAssembly(typeof(IInstancePrototype)).GetTypes()
                .Where(x => x.GetInterface(typeof(IInstancePrototype).Name) != null && !x.IsInterface && !x.IsAbstract))
            {
                ((ObservableCollection<IInstancePrototype>)PickableObjects).Insert(0, (IInstancePrototype)Activator.CreateInstance(t));
            }

            _environment.AddInstance((IInstance)Player);
            _environment.Run();
        }
    }
}
