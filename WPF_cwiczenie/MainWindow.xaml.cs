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


using System.IO;
using Microsoft.Win32;

namespace WPF_cwiczenie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        WPF_BazaDanychEntities db = new WPF_BazaDanychEntities();  // połączenie z bazą danych
        List<String> zawartoscKoszyka = new List<String>(); 

        public void WypelnijComboBox() // funkcja wypełniająca ComboBox danymi z bazy
        {
            var zbior = db.Roslina;

            foreach (var encja in zbior)
            {
                RoslinkiComboBox.Items.Add(encja.nazwa_polska);
            }            
        }
        public MainWindow()
        {
            InitializeComponent();
            WypelnijComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodanieDoKoszyka.Visibility = Visibility.Visible; // odkrycie przycisku DodanieDoKoszyka
            var nazwaWybranegoPrzycisku = (sender as Button).Name;
            var zbior = db.Roslina;
            var encja = zbior.Where(en => en.nazwa_polska == nazwaWybranegoPrzycisku);
            var znaleziony = encja.FirstOrDefault<Roslina>();
            NazwaRosliny.Text = znaleziony.nazwa_polska;
            InfoRoslina.Text = "Nazwa polska: " + znaleziony.nazwa_polska + "\n" + "Nazwa łacińska: " + znaleziony.nazwa_lacinska + "\n" + "Rodzina: " + znaleziony.rodzina;
        }

        private void ZapisDoPliku_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog zapisDoPlikuDialog = new SaveFileDialog();
            zapisDoPlikuDialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            if (zapisDoPlikuDialog.ShowDialog() == true)
                File.WriteAllText(zapisDoPlikuDialog.FileName, InfoRoslina.Text);
        }

        private void OtwarcieKoszyka_Click(object sender, RoutedEventArgs e)
        {
            Koszyk koszyk = new Koszyk(zawartoscKoszyka);
            koszyk.Show();
        }

        private void DodanieDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            zawartoscKoszyka.Add(NazwaRosliny.Text);
        }

        private void RoslinkiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var wybrany = (string)RoslinkiComboBox.SelectedValue;
            var zbior = db.Roslina;
            var encja = zbior.Where(en => en.nazwa_polska == wybrany);
            var znaleziony = encja.FirstOrDefault<Roslina>();
            InfoRoslinaLista.Text = "Nazwa polska: " + znaleziony.nazwa_polska + "\n" + "Nazwa łacińska: " + znaleziony.nazwa_lacinska + "\n" + "Rodzina: " + znaleziony.rodzina;

        }
    }
}
