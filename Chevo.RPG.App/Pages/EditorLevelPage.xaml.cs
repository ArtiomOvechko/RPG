using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.ViewModel.Interfaces.Level;
using Chevo.RPG.ViewModel.Level;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chevo.RPG.App.Pages
{
    public partial class EditorLevelPage : Page
    {
        protected EditorLevel _currentLevel;

        public EditorLevelPage(EditorLevel level)
        {
            InitializeComponent();

            _currentLevel = level;

            DataContext = _currentLevel;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    _currentLevel.StopMove.Execute(Direction.Up);
                    break;
                case Key.D:
                    _currentLevel.StopMove.Execute(Direction.Right);
                    break;
                case Key.S:
                    _currentLevel.StopMove.Execute(Direction.Down);
                    break;
                case Key.A:
                    _currentLevel.StopMove.Execute(Direction.Left);
                    break;
                default: return;
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    _currentLevel.StartMove.Execute(Direction.Up);
                    break;
                case Key.D:
                    _currentLevel.StartMove.Execute(Direction.Right);
                    break;
                case Key.S:
                    _currentLevel.StartMove.Execute(Direction.Down);
                    break;
                case Key.A:
                    _currentLevel.StartMove.Execute(Direction.Left);                      
                    break;
                default:
                    return;
            }
        }

        private void OnPutPress(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point cursorPoint = Mouse.GetPosition(this);
            _currentLevel.PutObject.Execute(
                new Core.Stats.Point((int)cursorPoint.X - _currentLevel.ViewPort.Position.X, (int)cursorPoint.Y - _currentLevel.ViewPort.Position.Y));
        }

        private void OnDiscardPress(object sender, MouseButtonEventArgs e)
        {
            _currentLevel.DiscardObject.Execute(null);
        }
        private void OnPickPress(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement from = (FrameworkElement)sender;
            _currentLevel.PickObject.Execute(from.Tag);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point cursorPoint = Mouse.GetPosition(this);
            _currentLevel.MovePickedObject.Execute(
                new Core.Stats.Point((int)cursorPoint.X - _currentLevel.ViewPort.Position.X, (int)cursorPoint.Y - _currentLevel.ViewPort.Position.Y));
        }
    }
}
