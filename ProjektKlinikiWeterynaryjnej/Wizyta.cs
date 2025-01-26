using System;
using System.Runtime.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Wizyta
    [DataContract(Name = "Klinika", Namespace = "http://schemas.datacontract.org/2004/07/KlinikaWeterynaryjna")]
    public class Wizyta : ICloneable, IComparable<Wizyta>, IEquatable<Wizyta>
    {
        [DataMember]
        public DateTime Data { get; private set; }

        [DataMember]
        public Lekarz Lekarz { get; private set; }

        [DataMember]
        public Zwierze Zwierze { get; private set; }

        public Wizyta(DateTime data, Lekarz lekarz, Zwierze zwierze)
        {
            Data = data;
            Lekarz = lekarz;
            Zwierze = zwierze;
        }

        public override string ToString()
        {
            return $"Wizyta: {Data}, Lekarz: {Lekarz.Imie} {Lekarz.Nazwisko}, Zwierzę: {Zwierze.Imie}, {Zwierze.Rasa}";
        }

        public object Clone()
        {
            return new Wizyta(Data, Lekarz, Zwierze);
        }

        public int CompareTo(Wizyta? other)
        {
            return Data.CompareTo(other?.Data);
        }

        public bool Equals(Wizyta? other)
        {
            if (other == null) return false;
            return Data == other.Data && Lekarz.Equals(other.Lekarz) && Zwierze.Equals(other.Zwierze);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Wizyta);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode() ^ Lekarz.GetHashCode() ^ Zwierze.GetHashCode();
        }
    }
}
