using KlinikaWeterynaryjna;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KlinikaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy DodajWizytaWindow.xaml
    /// </summary>
    public partial class DodajWizytaWindow : Window
    {
        public DodajWizytaWindow()
        {

            InitializeComponent();
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");
            LekarzCombo.ItemsSource = klinika.Lekarze;
            ZwierzeCombo.ItemsSource = klinika.Zwierzeta;
        }

        private async void ZapiszDodajWizyta(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");

            DateTime? dataWizyty = Data.SelectedDate;
            Lekarz wybranyLekarz = (Lekarz)LekarzCombo.SelectedItem;
            Zwierze wybraneZwierze = (Zwierze)ZwierzeCombo.SelectedItem;

            // Walidacja danych
            if (wybranyLekarz is null || wybraneZwierze is null || !dataWizyty.HasValue)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tworzenie nowego lekarza i dodawanie do listy
            Wizyta nowaWizyta = new Wizyta(dataWizyty.Value, wybranyLekarz, wybraneZwierze);

            bool istniejeWizyta = klinika.Wizyty.Any(wizyta =>
            wizyta.Data == dataWizyty.Value && wizyta.Lekarz.Equals(wybranyLekarz));
            if (istniejeWizyta)
            {
                MessageBox.Show("Wizyta z tym samym lekarzem w podanej dacie już istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            klinika.DodajWizyte(nowaWizyta);

            try
            {
                klinika.ZapiszDaneDoPliku("klinika.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            var storyboard = (Storyboard)FindResource("AnimateImageStoryboard");
            storyboard.Begin();
            await Task.Delay(1800);

            string soundPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dzwieki", "sukces.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = soundPath;
            player.Load();
            player.Play();


            await Task.Delay(1500);
            WizytaWindow window = new WizytaWindow();
            window.Show();
            this.Close();
        }
        private void AnulujDodajWizyta(object sender, RoutedEventArgs e)
        {
            WizytaWindow window = new WizytaWindow();
            window.Show();
            this.Close();
        }
    }
}
