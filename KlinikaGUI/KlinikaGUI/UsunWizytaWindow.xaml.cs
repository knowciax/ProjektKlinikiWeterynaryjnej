using KlinikaWeterynaryjna;
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

namespace KlinikaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy UsunWizytaWindow.xaml
    /// </summary>
    public partial class UsunWizytaWindow : Window
    {
        public UsunWizytaWindow()
        {
            InitializeComponent();
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            if (klinika != null)
            {
                ListaWizytyUsun.ItemsSource = new ObservableCollection<Wizyta>(klinika.Wizyty);
            }
        }

        private void UsunUsunWizyta(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            var wybranaWizyta = (Wizyta)ListaWizytyUsun.SelectedItem;
            if (wybranaWizyta == null)
            {
                MessageBox.Show("Proszę zaznaczyć wizytę do usunięcia.", "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBoxResult result = MessageBox.Show(
                "Czy na pewno chcesz usunąć wizytę?",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                klinika.Wizyty.Remove(wybranaWizyta);
                MessageBox.Show(
                    "Wizyta została usunięta.",
                    "Informacja",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                klinika.ZapiszDaneDoPliku("klinika.xml");
                klinika = Klinika.WczytajDaneZPliku("klinika.xml");
                if (klinika != null)
                {
                    ListaWizytyUsun.ItemsSource = new ObservableCollection<Wizyta>(klinika.Wizyty);
                }
            }
        }

        private void WrocUsunWizyta(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            klinika.ZapiszDaneDoPliku("klinika.xml");
            WizytaWindow window = new WizytaWindow();
            window.Show();
            this.Close();
        }
    }
}
