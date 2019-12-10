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

namespace Wpf_Coursework_GenSim_Upgraded__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Storage storage = new Storage();
            storage.Show();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            Image l = e.Data.GetData(typeof(Image)) as Image;

            Panel element = l.Parent as Panel;
            element.Children.Remove(l);
            gridBees.Children.Add(l);
        }
    }
}
