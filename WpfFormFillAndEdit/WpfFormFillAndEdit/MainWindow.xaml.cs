using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFormFillAndEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> allEmp = new List<Employee>();
        Employee employee = new Employee();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var emp = (dgData.SelectedItem);



            //txtAge.Text = emp[0].Name;
            //if (dgData.SelectedItems.Count > 1) { }


            var row = dgData.SelectedItem as Employee;
            if (row != null)
            {
                txtName.Text = row.Name;
                txtAge.Text = row.Age;
                txtSex.Text = row.Sex;
                txtPlace.Text = row.Place;
                txtDesg.Text = row.Designation;

            }
            employee = row;
            dgData.Items.Remove(dgData.SelectedItem);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Employee objEmp = new Employee();
            objEmp.Name = txtName.Text;
            objEmp.Age = txtAge.Text;
            objEmp.Sex = txtSex.Text;
            objEmp.Place = txtPlace.Text;
            objEmp.Designation = txtDesg.Text;

            dgData.Items.Add(objEmp);
            allEmp.Add(objEmp);
            txtName.Text = txtAge.Text = txtPlace.Text = txtSex.Text = txtDesg.Text = String.Empty;
            
        }

        private void dgData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGrid_SelectionChanged(null,null);
        }

        private void dgData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //Employee emp = new Employee();
            //var obj = dgData.SelectedItem;
            //emp = (Employee)obj;
            //txtPlace.Text = emp.Name;
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            //var dg = dgData.SelectedItem["Employee"];
           // if (dg != null )
            {
                // Employee emp = (Employee)dg.;

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employee objEmp = (Employee)dgData.SelectedItem;
            objEmp.Name = txtName.Text;
            objEmp.Age = txtAge.Text;
            objEmp.Sex = txtSex.Text;
            objEmp.Place = txtPlace.Text;
            objEmp.Designation = txtDesg.Text;
            dgData.Items.Refresh();
            txtName.Text = txtAge.Text = txtPlace.Text = txtSex.Text = txtDesg.Text = String.Empty;

        }
    }
}
