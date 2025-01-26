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
using System.Windows.Resources;
using System.Windows.Shapes;
using KlinikaWeterynaryjna;

namespace KlinikaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy DodajLekarzWindow.xaml
    /// </summary>
    public partial class DodajLekarzWindow : Window
    {
        public DodajLekarzWindow()
        {
            InitializeComponent();
        }

        private async void ZapiszDodajLekarz(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");

            string imie = TextImie.Text;
            string nazwisko = TextNazwisko.Text;
            string specjalizacja = TextSpecjalizacja.Text;

            // Walidacja danych
            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(specjalizacja))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tworzenie nowego lekarza i dodawanie do listy
            Lekarz nowyLekarz = new Lekarz(imie, nazwisko, specjalizacja);

            if (klinika.Lekarze.Contains(nowyLekarz))
            {
                MessageBox.Show("Lekarz o podanych danych już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            klinika.DodajLekarza(nowyLekarz);

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
            LekarzWindow window = new LekarzWindow();
            window.Show();
            this.Close();
        }
        private void AnulujDodajLekarz(object sender, RoutedEventArgs e)
        {
            LekarzWindow window = new LekarzWindow();
            window.Show();
            this.Close();
        }
    }
}
