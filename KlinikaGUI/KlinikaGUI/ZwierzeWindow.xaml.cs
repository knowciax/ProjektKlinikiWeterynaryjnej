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
    /// Logika interakcji dla klasy ZwierzeWindow.xaml
    /// </summary>
    public partial class ZwierzeWindow : Window
    {
        public ZwierzeWindow()
        {
            InitializeComponent();
            Klinika klinika = Klinika.WczytajDaneZPliku("klinika.xml");        
            if (klinika != null)
            {
                ListaZwierzeta.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
            }
        }

        private void DodajZwierze(object sender, RoutedEventArgs e)
        {
            DodajZwierzeWindow window = new DodajZwierzeWindow();
            window.Show();
            this.Close();
        }

        private void WrocZwierze(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
