using System.Runtime.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Osoba
    [DataContract(Name = "Klinika", Namespace = "http://schemas.datacontract.org/2004/07/KlinikaWeterynaryjna")]
    public abstract class Osoba
    {
        [DataMember]
        public string Imie { get; private set; } = string.Empty;

        [DataMember]
        public string Nazwisko { get; private set; } = string.Empty;

        protected Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public virtual string Opis()
        {
            return $"{Imie} {Nazwisko}";
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
