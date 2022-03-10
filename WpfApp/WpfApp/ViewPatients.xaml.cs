using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ViewPatients.xaml
    /// </summary>
    public partial class ViewPatients : Window
    {
        public ViewPatients()
        {
            InitializeComponent();
            GetDetails();
        }
        void GetDetails()
        {
            List<Patient> patients = new List<Patient>();
            using (StreamReader reader = new StreamReader("Patient.txt"))
            {
                while (true)
                {
                    string prsr = reader.ReadLine();
                    if (prsr == null)
                    {
                        break;
                    }
                    Patient p = new Patient();
                    string[] details = prsr.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    p.Id = int.Parse(details[0]);
                    p.Name = details[1];
                    p.Age = int.Parse(details[2]);
                    p.Gender = (details[3].Trim().ToLower() == "male" )? Gender.Male : Gender.Female;
                    string a = (string)details[3].ToString();
                   
                    p.Phone = details[4];
                    p.Address = details[5];
                    p.Date = details[6];
                    patients.Add(p);
                    lvPatient.ItemsSource = patients;
                }

            }

        }
    }
}
