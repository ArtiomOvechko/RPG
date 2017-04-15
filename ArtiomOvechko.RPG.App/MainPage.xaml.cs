using ArtiomOvechko.RPG.Core.Spec;
using ArtiomOvechko.RPG.ViewModel.Control;
using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;
using ArtiomOvechko.RPG.ViewModel.Level;
using ArtiomOvechko.RPG.Common.Settings;
using ArtiomOvechko.RPG.Core.Enum;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArtiomOvechko.RPG.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        protected ILevel _currentLevel;
        protected bool _isKeyPressed;

        public MainPage()
        {
            InitializeComponent();

            _currentLevel = new Sanctuary();

            // Init Player
            Spec playerSpec = new Spec(2700, 2700);
            var viewPoint = Helpers.ScreenCentering.GetInstance.GetCanvasOffset(new Common.Helpers.Point(playerSpec.XPos, playerSpec.YPos));
            _currentLevel.ViewPort = new ViewPort(GlobalSettings.LevelWidth, GlobalSettings.LevelWidth, viewPoint);

            _isKeyPressed = false;
            DataContext = _currentLevel;
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.W:
                case Windows.System.VirtualKey.Up:
                    _currentLevel.StopMove.Execute(Direction.Up);
                    break;
                case Windows.System.VirtualKey.D:
                case Windows.System.VirtualKey.Right:
                    _currentLevel.StopMove.Execute(Direction.Right);
                    break;
                case Windows.System.VirtualKey.S:
                case Windows.System.VirtualKey.Down:
                    _currentLevel.StopMove.Execute(Direction.Down);
                    break;
                case Windows.System.VirtualKey.A:
                case Windows.System.VirtualKey.Left:
                    _currentLevel.StopMove.Execute(Direction.Left);
                    break;
                case Windows.System.VirtualKey.Enter:
                    _currentLevel.TryInteract.Execute(null);
                    break;
                case Windows.System.VirtualKey.Space:
                    _currentLevel.Attack.Execute(null);
                    break;
            }
            _isKeyPressed = false;
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (!_isKeyPressed)
            {
                _isKeyPressed = true;
                switch (e.Key)
                {
                    case Windows.System.VirtualKey.W:
                    case Windows.System.VirtualKey.Up:
                        _currentLevel.StartMove.Execute(Direction.Up);
                        break;
                    case Windows.System.VirtualKey.D:
                    case Windows.System.VirtualKey.Right:
                        _currentLevel.StartMove.Execute(Direction.Right);
                        break;
                    case Windows.System.VirtualKey.S:
                    case Windows.System.VirtualKey.Down:
                        _currentLevel.StartMove.Execute(Direction.Down);
                        break;
                    case Windows.System.VirtualKey.A:
                    case Windows.System.VirtualKey.Left:
                        _currentLevel.StartMove.Execute(Direction.Left);
                        break;
                }
            }
        }
    }
}
