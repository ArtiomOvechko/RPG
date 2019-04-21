using Chevo.RPG.Core.Enum;
using Chevo.RPG.ViewModel.Interfaces.Level;

using System.Windows.Controls;
using System.Windows.Input;

namespace Chevo.RPG.App.Pages
{
    public partial class GameLevelPage : Page
    {
        protected ILevel _currentLevel;

        public GameLevelPage(ILevel level)
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
                case Key.Enter:
                    _currentLevel.TryInteract.Execute(null);
                    break;
                //case Key.Space:
                //    _currentLevel.Attack.Execute(null);
                //    return;
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

        private void OnEquipPress(object sender, MouseButtonEventArgs e)
        {
            Label from = (Label)sender;
            _currentLevel.EquipWeapon.Execute(from.Tag);
        }

        private void OnUnequipPress(object sender, MouseButtonEventArgs e)
        {
            _currentLevel.UnequipWeapon.Execute(null);
        }

        private void OnDiscardPress(object sender, MouseButtonEventArgs e)
        {
            Label from = (Label)sender;
            _currentLevel.DiscardWeapon.Execute(from.Tag);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point cursorPoint = Mouse.GetPosition(this);
            _currentLevel.Aim.Execute(
                new Core.Stats.Point((int)cursorPoint.X, (int)cursorPoint.Y));
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _currentLevel.Attack.Execute(null);
        }
    }
}
