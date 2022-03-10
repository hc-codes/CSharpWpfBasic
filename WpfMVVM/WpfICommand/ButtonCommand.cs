using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfICommand.ViewModel;

namespace WpfICommand
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ButtonViewModel _buttonViewModel;
        public ButtonCommand(ButtonViewModel ViewModel)
        {
            _buttonViewModel = ViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _buttonViewModel.OnExecute();
        }
    }


    
}
