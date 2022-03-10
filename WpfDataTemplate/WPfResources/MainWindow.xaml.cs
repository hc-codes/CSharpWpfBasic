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

namespace WPfResources
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

        private void btnToRed_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["Dynamic"] = Brushes.Red;
        }

        private void btnToBlack_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["Dynamic"] = Brushes.Black;
        }
    }
}
