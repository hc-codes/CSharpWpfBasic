using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfMVVMStudent.Commands;
using WpfMVVMStudent.Model;

namespace WpfMVVMStudent.ViewModel
{
  
    public class StudentViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Student _student;
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private ObservableCollection<Student> _students;  //Students Collection 
        private ICommand _SubmitCommand, _SelectedItem;

        /// <summary>
        /// Constructor
        /// </summary>
        public StudentViewModel()
        {
            Student = new Student();
            Students = new ObservableCollection<Student>();
        }
        public Student Student
        {
            get { return _student; }
            set
            {   
                _student = value;
                if (Student?.Name!=null)
                {
                    if(Student.Name.Length<4)
                        AddError(nameof(_student.Name), "Length of Name must be greater than 4");
                }
                RaisePropertyChange("Student"); 
            }
        } // Property


        public ObservableCollection<Student> Students //Property to notify change
        {
            get { return _students; }
            set
            {
                _students = value;
                RaisePropertyChange("Students");
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


        private Student selectedUser;
        public Student SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                SelectionChanged(selectedUser);
                RaisePropertyChange("SelectedUser");
            }
        }

        private void SelectionChanged(Student selectedUser)
        {
            Student = selectedUser;

        }

        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public ICommand SubmitCommand //Readonly property
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }
        private void SubmitExecute(object parameter)
        {
            Students.Add(Student);
            Student = new Student();
            new Department();
        }
        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Student.Name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
            }
            _errors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
