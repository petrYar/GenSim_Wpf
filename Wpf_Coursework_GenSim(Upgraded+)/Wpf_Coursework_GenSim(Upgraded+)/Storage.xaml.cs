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
using System.Windows.Shapes;

namespace Wpf_Coursework_GenSim_Upgraded__
{
    /// <summary>
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop(imgBee, imgBee, DragDropEffects.Move);
        }

        private void ImgBee_Drop(object sender, DragEventArgs e)
        {
            Image i = e.Data.GetData(typeof(Image)) as Image;

            StorageGrid.Children.Remove(i);
            StorageGrid.Children.Add(i);
        }
    }
}
