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

namespace WpfDragAndDropControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isClicked = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnDrag_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isClicked)
            {
                var dragPosition = e.GetPosition(myCanvas);
                Canvas.SetLeft(btnDrag, dragPosition.X - 75);
                Canvas.SetTop(btnDrag, dragPosition.Y - 25);
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
                Brush brush1 = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
                myCanvas.Background = brush;
                btnDrag.Background = brush1;
            }
        }
        static Random random = new Random();



        private void btnDrag_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isClicked = true;
        }

        private void btnDrag_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isClicked = false;
        }
    }
}
