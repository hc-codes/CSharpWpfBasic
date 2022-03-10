using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WpfMVVMDataValidation.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _name;
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if(_name.Length<4)
                    AddError(nameof(_name), "Length of Name must be greater than 4");

            }
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

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.GetValueOrDefault(propertyName, null);
        }
    }
}
