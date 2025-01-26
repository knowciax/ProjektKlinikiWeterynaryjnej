using System;
using System.Runtime.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Lekarz
    [DataContract(Name = "Klinika", Namespace = "http://schemas.datacontract.org/2004/07/KlinikaWeterynaryjna")]
    public class Lekarz : Osoba, IEquatable<Lekarz>, IComparable<Lekarz>
    {
        [DataMember]
        public string Specjalizacja { get; private set; } = string.Empty;

        public Lekarz(string imie, string nazwisko, string specjalizacja) : base(imie, nazwisko)
        {
            Specjalizacja = specjalizacja;
        }

        public override string Opis()
        {
            return $"Dr {base.Opis()} - Specjalizacja: {Specjalizacja}";
        }

        public bool Equals(Lekarz? other)
        {
            if (other == null) return false;
            return Imie == other.Imie && Nazwisko == other.Nazwisko && Specjalizacja == other.Specjalizacja;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Lekarz);
        }

        public override int GetHashCode()
        {
            return Imie.GetHashCode() ^ Nazwisko.GetHashCode() ^ Specjalizacja.GetHashCode();
        }

        public int CompareTo(Lekarz? other)
        {
            if (other == null) return 1;
            return string.Compare(Imie, other.Imie, StringComparison.Ordinal);
        }
        public override string ToString()
        {
            return $"Dr {base.ToString()} - Specjalizacja: {Specjalizacja}";
        }
    }
}
