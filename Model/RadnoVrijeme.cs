using System;

namespace Model
{
    public class RadnoVrijeme
    {
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }


        public RadnoVrijeme(DateTime pocetak, DateTime kraj)
        {
            Pocetak = pocetak;
            Kraj = kraj;
        }

        public RadnoVrijeme()
        {

        }
    }
}
