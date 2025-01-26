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
    /// Logika interakcji dla klasy DodajZwierzeWindow.xaml
    /// </summary>
    public partial class DodajZwierzeWindow : Window
    {
        public DodajZwierzeWindow()
        {
            InitializeComponent();
        }

        private void Wartosc(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TextSlider != null)
            {
                TextSlider.Text = SliderWiek.Value.ToString("0");
            }
        }

        private async void ZapiszDodajZwierze(object sender, RoutedEventArgs e)
        {
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");

            string imie = TextImie.Text;
            int wiek = (int)SliderWiek.Value;
            string rasa = TextRasa.Text;

            // Walidacja danych
            if (string.IsNullOrWhiteSpace(imie) || wiek == 0 || string.IsNullOrWhiteSpace(rasa))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tworzenie nowego lekarza i dodawanie do listy
            Zwierze noweZwierze = new Zwierze(imie, wiek, rasa);

            if (klinika.Zwierzeta.Contains(noweZwierze))
            {
                MessageBox.Show("Zwierzę o podanych danych już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            klinika.DodajZwierze(noweZwierze);

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
        private void AnulujDodajZwierze(object sender, RoutedEventArgs e)
        {
            ZwierzeWindow window = new ZwierzeWindow();
            window.Show();
            this.Close();
        }
    }
}
