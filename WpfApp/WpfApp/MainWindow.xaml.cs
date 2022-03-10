using System;
using System.Collections.Generic;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app helps you to register and view patient details.", "Help", MessageBoxButton.OK); ;
        }

        private void ViewPatientClick(object sender, RoutedEventArgs e)
        {
            ViewPatients patients = new ViewPatients();
            patients.Show();
            this.Hide();
        }
    }
}
