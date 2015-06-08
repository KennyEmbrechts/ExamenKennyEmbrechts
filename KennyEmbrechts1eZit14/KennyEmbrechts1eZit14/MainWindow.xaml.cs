using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KennyEmbrechts1eZit14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public ObservableCollection<Personen> Personenlijst { get; set; }
        public ObservableCollection<Personen> Gezochtelijst { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaadJson(object sender, RoutedEventArgs e)
        {
            Personenlijst = new ObservableCollection<Personen>(Mensen.readJsonData());
            LijstPersonen.ItemsSource = Personenlijst;
        }

        private void JongerDan30Zoeken(object sender, RoutedEventArgs e)
        {
            decimal MensenOver30 = (from persoon in Personenlijst
                                  where persoon.age < 30
                                  select persoon).Count();


            MessageBox.Show(Convert.ToString("Er is "+MensenOver30+"persoon jonger dan 30"));
            
        }

        private void VrouwenLeeftijden(object sender, RoutedEventArgs e)
        {
            decimal Leeftijden = (from persoon in Personenlijst where persoon.gender=="female"
                                    select persoon.age).Sum();
            MessageBox.Show(Convert.ToString(Leeftijden));
        }

        private void SorteerOpNaamEnToon3(object sender, RoutedEventArgs e)
        {
            Gezochtelijst = new ObservableCollection<Personen>();
            var number = (from n in Personenlijst orderby n.name select n).Take(3);

            foreach (var i1 in number)
            {
                Gezochtelijst.Add(i1);
            }
            LijstPersonen.ItemsSource = Gezochtelijst;
        }

        private void VerhoogLeeftijdMet1(object sender, RoutedEventArgs e)
        {
            Personen SelectedHuman = (Personen)LijstPersonen.SelectedItem;
            SelectedHuman.age++;
        }
    }
}
