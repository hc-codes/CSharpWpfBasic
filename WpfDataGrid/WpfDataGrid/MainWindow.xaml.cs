using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uri source = default;
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Student std = new Student();
            std.Name = txtName.Text;
            if (Validators.PhoneValidator(txtPhone.Text))
            {
                std.Phone = long.Parse(txtPhone.Text);
            }
            else
            {
                MessageBox.Show("Invalid Phone Number", "Error", MessageBoxButton.OKCancel);
                return;
            }

            if (int.Parse(dpDOB.SelectedDate.Value.ToString("yyyy")) < 1999)
            {
                std.DOB = (dpDOB.SelectedDate.Value.ToString("yyyy-MM-dd"));
                dpDOB.BorderBrush = Brushes.Black;

            }
            Progress();
            Thread.Sleep(100);
            if (ckMal.IsChecked == true)
            {
                if (ckEng.IsChecked == true && ckHindi.IsChecked == true)
                {
                    std.Language = ckMal.Content.ToString() + ", " + ckEng.Content.ToString() + ", " + ckHindi.Content.ToString();
                }
                else if (ckEng.IsChecked == true)
                {
                    std.Language = ckMal.Content.ToString() + ", " + ckEng.Content.ToString();
                }
                else if (ckHindi.IsChecked == true)
                {
                    std.Language = ckMal.Content.ToString() + ", " + ckHindi.Content.ToString();
                }
                else
                {
                    std.Language = ckMal.Content.ToString();
                }
            }
            else if (ckEng.IsChecked == true)
            {
                if (ckHindi.IsChecked == true)
                {
                    std.Language = ckEng.Content.ToString() + ", " + ckHindi.Content.ToString();
                }
                else
                {
                    std.Language = ckEng.Content.ToString();
                }
            }
            else
            {
                std.Language = ckHindi.Content.ToString();
            }
            std.Semester = cbSem.SelectionBoxItem.ToString();
            std.Gender = (bool)rbMale.IsChecked ? rbMale.Content.ToString() : rbFemale.Content.ToString();
            std.Path = source;
            dgDetails.Items.Add(std);
            ClearData();
            pg1.Value = default;

        }
        private void Progress()
        {

            DoubleAnimation doubleAnimation = new DoubleAnimation(200.0, new Duration(TimeSpan.FromMilliseconds(1000)));
            pg1.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);
            MessageBox.Show("Details Saved Successfully!!!", "Success", MessageBoxButton.OK);

            //grid.Children.Add(pg1);
            DoubleAnimation doubleAnimation1 = new DoubleAnimation(0.0, new Duration(TimeSpan.FromMilliseconds(10)));
            pg1.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation1);


        }
        private void ClearData()
        {
            txtName.Text = txtPhone.Text = String.Empty;
            dpDOB.SelectedDate = null;
            ckMal.IsChecked = ckEng.IsChecked = ckHindi.IsChecked = false;
            cbSem.SelectedItem = null;
            rbMale.IsChecked = rbFemale.IsChecked = false;
        }

        private void dgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            ckEng.IsChecked = ckMal.IsChecked = ckHindi.IsChecked = false;
            var row_selected = dgDetails.SelectedItem as Student;
            if (row_selected != null)
            {
                image.IsEnabled = true;
                image.Source = new BitmapImage(row_selected.Path);
                txtName.Text = row_selected.Name;
                txtPhone.Text = row_selected.Phone.ToString();
                dpDOB.SelectedDate = DateTime.Parse(row_selected.DOB.ToString());
                string[] res = row_selected.Language.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in res)
                {
                    if (item.Trim().ToLower() == "mal")
                    {
                        ckMal.IsChecked = true;
                    }

                    if (item.Trim().ToLower() == "eng")
                    {
                        ckEng.IsChecked = true;
                    }

                    if (item.Trim().ToLower() == "hindi")
                    {
                        ckHindi.IsChecked = true;
                    }

                }
                int index = 0;
                foreach (var item in cbSem.Items)
                {
                    var str = item.ToString();
                    if (str.Contains(row_selected.Semester))
                    {
                        break;
                    }
                    index++;
                }
                cbSem.SelectedIndex = index;

                if (row_selected.Gender.ToLower() == "male")
                {
                    rbMale.IsChecked = true;
                }
                else
                {
                    rbFemale.IsChecked = true;
                }
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.Items.Count == 0 || dgDetails.SelectedItem == null)
            {
                btnUpdate.IsEnabled = false;
                return;
            }
            Student objEmp = (Student)dgDetails.SelectedItem;
            objEmp.Name = txtName.Text;
            objEmp.Phone = long.Parse(txtPhone.Text);
            objEmp.DOB = dpDOB.SelectedDate.Value.ToShortDateString();
            string s = String.Empty;
            if (ckEng.IsChecked == true)
            {
                s = s + ckEng.Content.ToString() + " ,";
            }
            if (ckHindi.IsChecked == true)
            {
                s = s + ckHindi.Content.ToString() + " ,";
            }
            if (ckMal.IsChecked == true)
            {
                s = s + ckMal.Content.ToString() + " ,";
            }
            objEmp.Language = s;
            objEmp.Semester = cbSem.Text;
            objEmp.Gender = rbMale.IsChecked == true ? "Male" : "Female";
            MessageBox.Show("Details Updated Successfully");
            dgDetails.Items.Refresh();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgDetails.SelectedItem != null)
            {
                if (MessageBox.Show("Are You Sure to Remove?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    dgDetails.Items.RemoveAt(dgDetails.SelectedIndex);
                    ClearData();
                }

            }

        }

        private void txtName_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtName.Text.Length < 3)
            {
                btnSave.IsEnabled = false;
                ToolTip t = new ToolTip();
                t.Content = "Invalid Name";
                t.IsOpen = true;
                txtName.ToolTip = t;
            }

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ToolTip t = new ToolTip();
            if (txtName.Text.Length < 3)
            {
                btnSave.IsEnabled = false;
                t.Content = "Name: Length > 3 and < 12";
                txtName.ToolTip = t;
                txtName.BorderBrush = Brushes.Red;
            }
            else
                txtName.BorderBrush = Brushes.Black;

        }

        private void dpDOB_CalendarOpened(object sender, RoutedEventArgs e)
        {
            if (dpDOB.SelectedDate.HasValue && int.Parse(dpDOB.SelectedDate.Value.ToString("yyyy")) > 1999)
            {
                dpDOB.BorderBrush = Brushes.Red;
                return;
            }
            else if (dpDOB.SelectedDate.HasValue == false)
            {
                ToolTip t = new ToolTip();
                t.Content = "Please Select A Date";
                dpDOB.ToolTip = t;
                dpDOB.BorderBrush = Brushes.Red;
            }
            else
                dpDOB.BorderBrush = Brushes.Black;
        }

        private void dpDOB_CalendarOpened_1(object sender, RoutedEventArgs e)
        {

        }


        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ToolTip t = new ToolTip();
            if (!Validators.PhoneValidator(txtPhone.Text))
            {
                btnSave.IsEnabled = false;
                txtPhone.BorderBrush = Brushes.Red;
                t.Content = "Enter 10 Digit Mobile Number ";
                txtPhone.ToolTip = t;

            }
            else
            {
                btnSave.IsEnabled = true;
                txtPhone.BorderBrush = Brushes.Black;
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\Hari\source\C#Basics\C#WpfBasic\WpfDataGrid\WpfDataGrid\bin\Debug\Images";
            Nullable<bool> result = open.ShowDialog();
            if (result == true)
            {
                Image image1 = new Image();
                Uri file1 = new Uri(open.FileName);
                //File.Copy(open.FileName,$"..\\Images/{System.IO.Path.GetFileName(open.FileName)}");
                source = file1;
                image.Source = new BitmapImage(file1);

                grid.Children.Add(image);
                Grid.SetRow(image, 3);
                Grid.SetColumn(image, 3);

            }
        }

        private void dgDetails_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }
    }
    public class Student 
    {
        public string Name { get; set; }
        public long Phone { get; set; }
        public string DOB { get; set; }
        public string Language { get; set; }
        public string Semester { get; set; }
        public string Gender { get; set; }
        public Uri Path { get; set; }
    }
}
