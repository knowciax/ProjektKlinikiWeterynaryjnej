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
using KlinikaWeterynaryjna;

namespace KlinikaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Klinika z = Klinika.WczytajDaneZPliku("klinika.xml");
        }

        private void PrzejdzWizytyMain(object sender, RoutedEventArgs e)
        {
            WizytaWindow window = new WizytaWindow();
            window.Show();
            this.Close();
        }
        private void PrzejdzLekarzeMain(object sender, RoutedEventArgs e)
        {
            LekarzWindow window = new LekarzWindow();
            window.Show();
            this.Close();
        }
        private void PrzejdzZwierzetaMain(object sender, RoutedEventArgs e)
        {
            ZwierzeWindow window = new ZwierzeWindow();
            window.Show();
            this.Close();
        }
        private void WyjdzMain(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
