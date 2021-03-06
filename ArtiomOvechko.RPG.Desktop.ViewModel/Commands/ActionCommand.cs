﻿using System;
using System.Windows.Input;

namespace ArtiomOvechko.RPG.Desktop.ViewModel.Commands
{
    public class ActionCommand : ICommand
    {
        Action<object> _action;

        public ActionCommand(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
