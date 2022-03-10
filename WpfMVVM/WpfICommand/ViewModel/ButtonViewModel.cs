using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfICommand.ViewModel
{
    public class ButtonViewModel 
    {
        public ButtonCommand ButtonCommand { get; set; }

        public ButtonViewModel()
        {
            ButtonCommand = new ButtonCommand(this);
        }
        public void OnExecute()
        {
            MessageBox.Show("Clicked");
        }
    }
}
