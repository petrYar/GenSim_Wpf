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

namespace Wpf_2_Containers
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
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            const int STEP = 20;
            if (e.Key == Key.W && Canvas.GetTop(image) - STEP > -12)
                Canvas.SetTop(image, Canvas.GetTop(image) - STEP);
            else if (e.Key == Key.A && Canvas.GetLeft(image) - STEP > -8)
                Canvas.SetLeft(image, Canvas.GetLeft(image) - STEP);
            else if (e.Key == Key.S && Canvas.GetTop(image) + STEP < this.Height / 1.2)
                Canvas.SetTop(image, Canvas.GetTop(image) + STEP);
            else if (e.Key == Key.D && Canvas.GetLeft(image) + STEP < this.Width / 1.08)
                Canvas.SetLeft(image, Canvas.GetLeft(image) + STEP);
        }
    }
}
