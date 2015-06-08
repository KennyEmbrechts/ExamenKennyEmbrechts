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
            Gezochtelijst = new ObservableCollection<Personen>();

            var Menskens = Personenlijst.Where(t => t.age<30);

            foreach (var i1 in Menskens)
            {
                Gezochtelijst.Add(i1);
            }
            LijstPersonen.ItemsSource = Gezochtelijst;
            
        }

        private void VrouwenLeeftijden(object sender, RoutedEventArgs e)
        {
            var Menskens = Personenlijst.Where(t => t.age > 0).Sum(g => g.age);
            MessageBox.Show(Convert.ToString(Menskens));
        }

        private void SorteerOpNaamEnToon3(object sender, RoutedEventArgs e)
        {

        }

        private void VerhoogLeeftijdMet1(object sender, RoutedEventArgs e)
        {
            Personen temp = this.DataContext as Personen;
            temp.age++;
        }
    }
}
