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
using static Wpf_Coursework_GenSim_Upgraded__.GeneticSimulator;

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
            List<Bee> bees = new List<Bee>()
            {
                new Bee()
                {
                    Name="бджола",
                    //Image = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images\image.jpg"), UriKind.Absolute));     
                }
            };
            StorageList.ItemsSource = bees;
        }

        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
        }

        private void ImgBee_Drop(object sender, DragEventArgs e)
        {
            Image elem = e.Data.GetData(typeof(Image)) as Image;

            Panel element = elem.Parent as Panel;
            element.Children.Remove(element);

            //StorageList.Children.Add(element);
        }

        private void StorageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DragDrop.DoDragDrop(this, this, DragDropEffects.Move);
        }
    }
}
