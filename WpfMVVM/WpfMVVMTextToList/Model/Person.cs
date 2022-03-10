using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfMVVMTextToList.Model
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
