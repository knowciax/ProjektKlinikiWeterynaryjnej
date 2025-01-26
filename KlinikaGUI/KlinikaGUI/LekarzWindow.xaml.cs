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
using System.Windows.Shapes;
using KlinikaWeterynaryjna;

namespace KlinikaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy LekarzWindow.xaml
    /// </summary>
    public partial class LekarzWindow : Window
    {
        public LekarzWindow()
        {
            InitializeComponent();
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            if (klinika != null)
            {
                ListaLekarze.ItemsSource = new ObservableCollection<Lekarz>(klinika.Lekarze);
            }
        }

        private void DodajLekarz(object sender, RoutedEventArgs e)
        {
            DodajLekarzWindow window = new DodajLekarzWindow();
            window.Show();
            this.Close();
        }

        private void WrocLekarz(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

    }
}
