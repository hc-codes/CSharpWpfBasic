using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WpfMVVMTextToList.Command;
using WpfMVVMTextToList.Model;

namespace WpfMVVM.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        private ObservableCollection<Person> _persons;  //Persons Collection 
        private ICommand _SubmitCommand;

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonViewModel()
        {
            Person = new Person();
            Persons = new ObservableCollection<Person>();
        }
        public Person Person// Property
        {
            get { return _person; }
            set { _person = value; NotifyPropertyChanged("Person"); }
        } 

        public ObservableCollection<Person> Persons //Property to notify change
        {
            get { return _persons; }
            set {
                _persons = value; 
                NotifyPropertyChanged("Persons"); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify Property Change  Method
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand SubmitCommand //Readonly property
        {
            get
            {
                if(_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }

        }
        private void SubmitExecute(object parameter)
        {
            Persons.Add(Person);
        }
        private bool CanSubmitExecute(object parameter)
        {
          
                return true;
            
        }
    }
}
