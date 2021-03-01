using System;

namespace Model
{
    public class Pacijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRođenja { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }

        public string PunoIme => $"{Ime} {Prezime}";
    }
}
