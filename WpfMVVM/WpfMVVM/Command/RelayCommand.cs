using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfMVVM.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;
        bool canExecuteCache;

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute, bool canExecuteCache)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
            canExecuteCache = canExecuteCache;
        }


        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;
            else
                return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

    }
}

