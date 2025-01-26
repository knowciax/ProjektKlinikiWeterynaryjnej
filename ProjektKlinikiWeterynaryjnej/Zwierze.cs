using System;
using System.Runtime.Serialization;

namespace KlinikaWeterynaryjna
{
    // Definicja wyjątku
    public class ZlyWiekException : Exception
    {
        public ZlyWiekException(string message) : base(message) { }
    }

    // Klasa Zwierze
    [DataContract(Name = "Klinika", Namespace = "http://schemas.datacontract.org/2004/07/KlinikaWeterynaryjna")]
    public class Zwierze : IEquatable<Zwierze>, ICloneable
    {
        [DataMember]
        public string Imie { get; private set; } = string.Empty;

        [DataMember]
        public int Wiek { get; private set; }

        [DataMember]
        public string Rasa { get; private set; } = string.Empty;

        public Zwierze(string imie, int wiek, string rasa)
        {
            if (wiek < 0)
                throw new ZlyWiekException("Wiek zwierzęcia nie może być ujemny!");

            Imie = imie;
            Wiek = wiek;
            Rasa = rasa;
        }

        public Zwierze() { }

        public override string ToString()
        {
            return $"Zwierzę: {Imie}, Wiek: {Wiek}, Rasa: {Rasa}";
        }

        public virtual string Opis()
        {
            return $"Zwierzę: {Imie}, Wiek: {Wiek}, Rasa: {Rasa}";
        }

        public bool Equals(Zwierze? other)
        {
            if (other == null) return false;
            return Imie == other.Imie && Wiek == other.Wiek && Rasa == other.Rasa;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Zwierze);
        }

        public override int GetHashCode()
        {
            return Imie.GetHashCode() ^ Wiek.GetHashCode() ^ Rasa.GetHashCode();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
