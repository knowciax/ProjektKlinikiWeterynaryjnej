using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Klinika
    [DataContract(Name = "Klinika", Namespace = "http://schemas.datacontract.org/2004/07/KlinikaWeterynaryjna")]
    public class Klinika
    {
        [DataMember]
        public List<Wizyta> Wizyty { get; private set; } = new List<Wizyta>();
        [DataMember]
        public List<Lekarz> Lekarze { get; private set; } = new List<Lekarz>();
        [DataMember]
        public List<Zwierze> Zwierzeta { get; private set; } = new List<Zwierze>();

        // Delegaty i zdarzenia
        public delegate void KlinikaEventHandler(string message);
        public event KlinikaEventHandler? OnLekarzDodany;
        public event KlinikaEventHandler? OnZwierzeDodane;
        public event KlinikaEventHandler? OnWizytaDodana;
        public event KlinikaEventHandler? OnWizytaUsunieta;

        public void DodajLekarza(Lekarz lekarz)
        {
            if (Lekarze.Contains(lekarz))
            {
                Console.WriteLine("Ten lekarz już istnieje.");
                return;
            }
            Lekarze.Add(lekarz);

            // Wywołanie zdarzenia
            OnLekarzDodany?.Invoke($"Dodano lekarza: {lekarz}");
        }

        public void DodajZwierze(Zwierze zwierze)
        {
            if (Zwierzeta.Contains(zwierze))
            {
                Console.WriteLine("To zwierzę już istnieje.");
                return;
            }
            Zwierzeta.Add(zwierze);

            // Wywołanie zdarzenia
            OnZwierzeDodane?.Invoke($"Dodano zwierzę: {zwierze}");
        }

        public void DodajWizyte(Wizyta wizyta)
        {
            Wizyty.Add(wizyta);

            // Wywołanie zdarzenia
            OnWizytaDodana?.Invoke($"Dodano wizytę: {wizyta}");
        }

        public bool UsunWizyte(Wizyta wizyta)
        {
            if (Wizyty.Remove(wizyta))
            {
                // Wywołanie zdarzenia
                OnWizytaUsunieta?.Invoke($"Usunięto wizytę: {wizyta}");
                return true;
            }
            Console.WriteLine("Nie znaleziono wizyty do usunięcia.");
            return false;
        }

        public void ZapiszDaneDoPliku(string sciezka)
        {
            var serializer = new DataContractSerializer(typeof(Klinika));
            using (var stream = new FileStream(sciezka, FileMode.Create))
            {
                serializer.WriteObject(stream, this);
            }
        }

        public static Klinika WczytajDaneZPliku(string sciezka)
        {
            var serializer = new DataContractSerializer(typeof(Klinika));
            using (var stream = new FileStream(sciezka, FileMode.Open))
            {
                return (Klinika)serializer.ReadObject(stream) ?? new Klinika();
            }
        }


        public void WyswietlLekarzy()
        {
            Console.WriteLine("Lista lekarzy:");
            foreach (var lekarz in Lekarze)
            {
                Console.WriteLine($"{lekarz.Opis()}");
            }
        }

        public void WyswietlZwierzeta()
        {
            Console.WriteLine("Lista zwierząt:");
            foreach (var zwierze in Zwierzeta)
            {
                Console.WriteLine(zwierze);
            }
        }

        public void WyswietlWizyty()
        {
            Console.WriteLine("Lista wizyt:");
            foreach (var wizyta in Wizyty)
            {
                Console.WriteLine(wizyta);
            }
        }
    }
}
