using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WpfMVVMStudent.Model
{
    public class Student : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Place { get; set; }
        public Department Department { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


        
    }

   
}
