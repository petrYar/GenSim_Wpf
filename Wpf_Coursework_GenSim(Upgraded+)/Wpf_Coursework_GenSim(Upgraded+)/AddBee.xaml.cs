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
    /// Interaction logic for AddBee.xaml
    /// </summary>
    public partial class AddBee : Window
    {
        public AddBee()
        {
            InitializeComponent();
        }
        Bee bee = new Bee();
        public Bee Bee()
        {
            return this.bee;
        }
        public void Clear()
        {
            this.bee = null;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            bee = new Bee(ProductEnter.Text, TypeEnter.Text, null/*доделать для вставки фото*/, NameEnter.Text, EffectEnter.Text,
                new Bee._Conditions(Cond_TempEnter.Value, Cond_HumidEnter.Value, Cond_FlowersEnter.Text, Cond_BiomEnter.Text),
                new Bee._Gens()/*сделать ввод генов(Отдельная форма)*/);
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
    }
}
