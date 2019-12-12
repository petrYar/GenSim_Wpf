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
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            bee = new Bee(null/*доделать для вставки фото*/,NameEnter.Text,ProductEnter.Text,TypeEnter.Text,EffectEnter.Text,
                new Bee._Conditions(Cond_TempEnter.Text,Cond_HumidEnter.Text,Cond_FlowersEnter.Text,Cond_BiomEnter.Text)/*,сделать ввод генов(Отдельная форма)*/);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
