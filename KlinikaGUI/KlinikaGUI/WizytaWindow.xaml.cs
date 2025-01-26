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
    /// Logika interakcji dla klasy WizytaWindow.xaml
    /// </summary>
    public partial class WizytaWindow : Window
    {
        public WizytaWindow()
        {
            InitializeComponent();
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            if (klinika != null)
            {
                ListaWizyty.ItemsSource = new ObservableCollection<Wizyta>(klinika.Wizyty);
            }
        }

        private void DodajWizyta(object sender, RoutedEventArgs e)
        {
            DodajWizytaWindow window = new DodajWizytaWindow();
            window.Show();
            this.Close();
        }
        private void UsunWizyta(object sender, RoutedEventArgs e)
        {
            UsunWizytaWindow window = new UsunWizytaWindow();
            window.Show();
            this.Close();
        }
        private void WrocWizyta(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void PosortujWizyta(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            var sortedWizyty = klinika.Wizyty.OrderBy(w => w.Data).ToList();
            klinika.Wizyty.Clear();

            foreach (var wizyta in sortedWizyty)
            {
                klinika.Wizyty.Add(wizyta);
            }
            if (klinika.Wizyty != null)
            {
                ListaWizyty.ItemsSource = new ObservableCollection<Wizyta>(klinika.Wizyty);
            }
            klinika.ZapiszDaneDoPliku("klinika.xml");
        }
    }
}
