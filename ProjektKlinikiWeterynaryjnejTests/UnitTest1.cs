using KlinikaWeterynaryjna;

namespace ProjektKlinikiWeterynaryjnejTests
{
    public class ZwierzeTests
    {
        [Fact]
        public void Pies_Creation_Success()
        {
            var zwierze = new Zwierze("Burek", 3, "Labrador");
            Assert.Equal("Burek", zwierze.Imie);
            Assert.Equal(3, zwierze.Wiek);
        }

        [Fact]
        public void Zwierze_NegativeAge_ThrowsException()
        {
            Assert.Throws<ZlyWiekException>(() => new Zwierze("Burek", -1, "Labrador"));
        }
    }

    public class OsobaTests
    {
        [Fact]
        public void Osoba_Creation_Success()
        {
            var osoba = new OsobaTest("Jan", "Kowalski");
            Assert.Equal("Jan", osoba.Imie);
            Assert.Equal("Kowalski", osoba.Nazwisko);
        }

        private class OsobaTest : Osoba
        {
            public OsobaTest(string imie, string nazwisko) : base(imie, nazwisko) { }
        }
    }
    public class LekarzTests
    {
        [Fact]
        public void Lekarz_Creation_Success()
        {
            var lekarz = new Lekarz("Anna", "Nowak", "Chirurgia");
            Assert.Equal("Anna", lekarz.Imie);
            Assert.Equal("Nowak", lekarz.Nazwisko);
            Assert.Equal("Chirurgia", lekarz.Specjalizacja);
        }

        [Fact]
        public void Lekarz_ToString_ReturnsCorrectFormat()
        {
            var lekarz = new Lekarz("Piotr", "Kowalski", "Dermatologia");
            Assert.Equal("Dr Piotr Kowalski - Specjalizacja: Dermatologia", lekarz.ToString());
        }
    }
}