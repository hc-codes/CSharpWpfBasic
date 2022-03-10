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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : UserControl
    {
        public Details()
        {

            InitializeComponent();

        }
        /// <summary>
        /// This method is used to generate items for the combo box i.e Age.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAge_MouseEnter(object sender, MouseEventArgs e)
        {
            for (int i = 1; i <= 120; i++)
            {
                cbAge.Items.Add(i);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Patient> patients = new List<Patient>();
            Patient patient = new Patient();
            patient.Id = GetNextId();
            patient.Name = txtName.Text;
            patient.Age = int.Parse(cbAge.SelectedItem.ToString());
            patient.Gender = (bool)rbMale.IsChecked ? Gender.Male : Gender.Female;
            patient.Phone = txtPhone.Text;
            patient.Address = txtAddress.Text;
            patient.Date = dpDate.SelectedDate.ToString();
            patients.Add(patient);
            SavePatientDetails(patients);
            MessageBox.Show("Details saved successfully...", "Saved", MessageBoxButton.OK);
            ClearData();
        }

        private void ClearData()
        {
            txtName.Text = txtPhone.Text = txtAddress.Text = String.Empty;
            rbMale.IsChecked = rbFemale.IsChecked = false;
            dpDate.SelectedDate = null;
            cbAge.Items.Clear();
        }
        private int GetCurrentId()
        {
            int id = 0;
            using (StreamReader reader = new StreamReader("Patient.txt"))
            {
                while (true)
                {
                    string prsr = reader.ReadLine();
                    if (prsr == null)
                    {
                        break;
                    }
                    string[] details = prsr.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    id = int.Parse(details[0]);

                }
            }
            return id;
        }
        private int GetNextId()
        {
            return GetCurrentId() + 1;
        }

        private void SavePatientDetails(List<Patient> patients)
        {
            using (StreamWriter writer = File.AppendText("Patient.txt"))
            {
                foreach (var item in patients)
                {
                    writer.WriteLine($"{item.Id}, {item.Name}, {item.Age}, {item.Gender}, {item.Phone}, {item.Address}, {item.Date}");
                }
            }
        }
    }
}
