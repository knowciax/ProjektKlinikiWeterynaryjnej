using System;

namespace KlinikaWeterynaryjna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Utworzenie obiektu Klinika
            var klinika = new Klinika();

            // Subskrypcja zdarzeń
            klinika.OnLekarzDodany += message => Console.WriteLine(message);
            klinika.OnZwierzeDodane += message => Console.WriteLine(message);
            klinika.OnWizytaDodana += message => Console.WriteLine(message);
            klinika.OnWizytaUsunieta += message => Console.WriteLine(message);

            try
            {
                // Tworzenie lekarzy
                var lekarze = new[]
                {
                    new Lekarz("Jan", "Kowalski", "Chirurgia"),
                    new Lekarz("Anna", "Nowak", "Dermatologia"),
                    new Lekarz("Marek", "Wiśniewski", "Ortopedia"),
                    new Lekarz("Katarzyna", "Zielińska", "Pediatria weterynaryjna"),
                    new Lekarz("Piotr", "Lewandowski", "Kardiologia"),
                    new Lekarz("Joanna", "Szymańska", "Oftalmologia"),
                    new Lekarz("Paweł", "Wójcik", "Neurologia"),
                    new Lekarz("Monika", "Kamińska", "Onkologia"),
                    new Lekarz("Tomasz", "Nowicki", "Urologia"),
                    new Lekarz("Ewa", "Jankowska", "Anestezjologia")
                };

                foreach (var lekarz in lekarze)
                {
                    klinika.DodajLekarza(lekarz);
                }

                // Tworzenie zwierząt
                var zwierzeta = new[]
                {
                    new Zwierze("Reksio", 5, "Owczarek niemiecki"),
                    new Zwierze("Mruczek", 3, "Kot czarny"),
                    new Zwierze("Burek", 7, "Labrador"),
                    new Zwierze("Fiona", 4, "Chihuahua"),
                    new Zwierze("Kleo", 2, "Kot brytyjski"),
                    new Zwierze("Azor", 6, "Golden retriever"),
                    new Zwierze("Luna", 1, "Królik miniaturowy"),
                    new Zwierze("Max", 8, "Bokser"),
                    new Zwierze("Bella", 3, "Cavalier king charles spaniel"),
                    new Zwierze("Dino", 10, "Dachshund"),
                    new Zwierze("Rocky", 4, "Rottweiler"),
                    new Zwierze("Zoe", 5, "Papuga falista"),
                    new Zwierze("Chester", 2, "Królik kalifornijski"),
                    new Zwierze("Oscar", 9, "Husky syberyjski"),
                    new Zwierze("Milo", 1, "Chomik syryjski")
                };

                foreach (var zwierze in zwierzeta)
                {
                    klinika.DodajZwierze(zwierze);
                }

                // Tworzenie wizyt
                var wizyty = new[]
                {
                    new Wizyta(DateTime.Now.AddDays(1), lekarze[0], zwierzeta[0]),
                    new Wizyta(DateTime.Now.AddDays(2), lekarze[1], zwierzeta[1]),
                    new Wizyta(DateTime.Now.AddDays(3), lekarze[2], zwierzeta[2]),
                    new Wizyta(DateTime.Now.AddDays(4), lekarze[3], zwierzeta[3]),
                    new Wizyta(DateTime.Now.AddDays(5), lekarze[4], zwierzeta[4]),
                    new Wizyta(DateTime.Now.AddDays(6), lekarze[5], zwierzeta[5]),
                    new Wizyta(DateTime.Now.AddDays(7), lekarze[6], zwierzeta[6]),
                    new Wizyta(DateTime.Now.AddDays(8), lekarze[7], zwierzeta[7]),
                    new Wizyta(DateTime.Now.AddDays(9), lekarze[8], zwierzeta[8]),
                    new Wizyta(DateTime.Now.AddDays(-10), lekarze[9], zwierzeta[9])
                };

                Wizyta w = wizyty[1].Clone() as Wizyta;

                foreach (var wizyta in wizyty)
                {
                    klinika.DodajWizyte(wizyta);
                }
                klinika.DodajWizyte(w);

                // Wyświetlanie danych
                Console.WriteLine("\n=== Lekarze ===");
                klinika.WyswietlLekarzy();

                Console.WriteLine("\n=== Zwierzęta ===");
                klinika.WyswietlZwierzeta();

                Console.WriteLine("\n=== Wizyty ===");
                klinika.WyswietlWizyty();

                // Usunięcie wizyty w
                if (klinika.UsunWizyte(w))
                {
                    Console.WriteLine("\nWizyta w została usunięta.");
                }

                klinika.Wizyty.Sort();

                Console.WriteLine("\n=== Wizyty po usunięciu i sortowaniu ===");
                klinika.WyswietlWizyty();

                Console.WriteLine("Czy wizyta1 i wizyta3 są równe? " + wizyty[1].Equals(wizyty[3]));

                // Zapis danych do pliku
                string sciezka = "klinika.xml";
                klinika.ZapiszDaneDoPliku(sciezka);
                Console.WriteLine($"\nDane zostały zapisane do pliku: {sciezka}");

                // Wczytanie danych z pliku
                Klinika klinika2 = Klinika.WczytajDaneZPliku(sciezka);
                Console.WriteLine("\nDane zostały wczytane z pliku.");
                klinika2.WyswietlWizyty();
                klinika2.WyswietlLekarzy();
                klinika2.WyswietlZwierzeta();
            }
            catch (ZlyWiekException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
