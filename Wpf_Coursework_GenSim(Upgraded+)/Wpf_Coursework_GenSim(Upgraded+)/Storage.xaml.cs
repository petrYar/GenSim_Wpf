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
            StorageList.Items.Add(new GeneticSimulator.Bee());
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // DragDrop.DoDragDrop(this, imgBee, DragDropEffects.Move);
        }

        private void ImgBee_Drop(object sender, DragEventArgs e)
        {
            Image elem = e.Data.GetData(typeof(Image)) as Image;

            Panel element = elem.Parent as Panel;
            element.Children.Remove(element);

            //StorageGrid.Children.Add(element);
        }
    }
}
