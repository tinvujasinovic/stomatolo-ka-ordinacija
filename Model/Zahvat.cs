namespace Model
{
    public class Zahvat
    {
        public int Id { get; set; }
        public string Šifra { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public Trajanje Trajanje { get; set; }

        public Zahvat(int id, string sifra, string naziv, decimal cijena, Trajanje trajanje)
        {
            Id = id;
            Šifra = sifra;
            Naziv = naziv;
            Cijena = cijena;
            Trajanje = trajanje;
        }
    }
}
