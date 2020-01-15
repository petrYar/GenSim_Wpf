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
using static Wpf_Coursework_GenSim_Upgraded__.GeneticSimulator;

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

        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop(whatToLearn, whatToLearn, DragDropEffects.Move);
        }
        
        private void Window_Drop(object sender, DragEventArgs e)
        {
            whatToLearn.DataContext = null;
            whatToLearn.DataContext = e.Data.GetData(typeof(Bee)) as Bee;
        }
        //----------------------------------------------//
        private void WhatToLearn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (whatToLearn.Children != null)
            {
                DragDrop.DoDragDrop(whatToLearn, whatToLearn.DataContext as Bee, DragDropEffects.Move);
                whatToLearn.Children.Clear();
            }
        }
    }
}
