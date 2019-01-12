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

namespace WPF_cwiczenie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WPF_BazaDanychEntities db = new WPF_BazaDanychEntities();  // połączenie z bazą danych
        public void fillComboBox() // funkcja wypełniająca ComboBox danymi z bazy
        {
            var roslinka = db.Roslina;

            foreach (var encja in roslinka)
            {
                roslinkiComboBox.Items.Add(encja.nazwa_polska);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nazwaWybranegoPrzycisku = (sender as Button).Name;
            var zbior = db.Roslina;
            var encja = zbior.Where(en => en.nazwa_polska == nazwaWybranegoPrzycisku);
            var znaleziony = encja.FirstOrDefault<Roslina>();
            infoRoslina.Text = "Nazwa polska: " + znaleziony.nazwa_polska + "\n" + "Nazwa łacińska: " + znaleziony.nazwa_lacinska + "\n" + "Rodzina: " + znaleziony.rodzina;
        }
    }
}
