using System;

namespace Model
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime Vrijeme { get; set; }
        public bool Završeno { get; set; }
        public Pacijent Pacijent { get; set; }
        public Zahvat Zahvat { get; set; }

        public Narudzba(DateTime _vrijeme, Pacijent _pacijent, Zahvat _zahvat)
        {
            Vrijeme = _vrijeme;
            Pacijent = _pacijent;
            Zahvat = _zahvat;
        }

        public override string ToString()
        {
            return $"{Zahvat.Šifra} - {Zahvat.Naziv} \n {Pacijent.PunoIme}";
        }
    }
}
