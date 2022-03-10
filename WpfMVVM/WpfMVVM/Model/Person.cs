using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfMVVM.Model
{
    public class Person : INotifyPropertyChanged
    {
        private string _fname, _lname, _fullname;
        public string FName
        {
            get { return _fname; }
            set { _fname = value; }// OnPropertyChanged(FName); }
        }
        public string LName
        {
            get { return _lname; }
            set { _lname = value; }// OnPropertyChanged(LName); }
        }
        public string FullName
        {
            get { return _fullname = _fname + " " + _lname; }
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
                ph(this, new PropertyChangedEventArgs(p));
        }
    }
}
