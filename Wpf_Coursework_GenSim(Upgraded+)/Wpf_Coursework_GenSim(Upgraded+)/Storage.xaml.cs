﻿using System;
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
        BeesRegistry bees = new BeesRegistry();
        public Storage()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth / 10;
            this.Top = SystemParameters.PrimaryScreenWidth / 7;
        }

        private void StorageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StorageList.SelectedItem != null)
            {
                DragDrop.DoDragDrop(StorageList, StorageList.SelectedItem, DragDropEffects.Move);
                bees.RemoveBee(StorageList.SelectedItem as Bee);
                RefreshStorage();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddBee addBee = new AddBee();
            addBee.ShowDialog();
            if (addBee.DialogResult == true)
            {
                bees.AddBee(addBee.Bee());
                RefreshStorage();
            }
            addBee.Clear();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (StorageList.SelectedItem != null)
            {
                bees.RemoveBee(StorageList.SelectedItem as Bee);
                RefreshStorage();
            }
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshStorage();
        }

        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            if (StorageList.SelectedItem != null)
            {
                bees.AddBee((StorageList.SelectedItem as Bee)._Clone());
                RefreshStorage();
            }
        }

        private void StPack_Click(object sender, RoutedEventArgs e)
        {
            bees.StandartPack();
            RefreshStorage();
        }

        public void RefreshStorage()
        {
            StorageList.ItemsSource = null;
            StorageList.ItemsSource = bees.GetList();
        }
        //----------------------------------------------//
        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop(StorageList, StorageList.ItemsSource, DragDropEffects.Move);
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            bees.AddBee(e.Data.GetData(typeof(Bee)) as Bee);
            RefreshStorage();
        }
    }
}
