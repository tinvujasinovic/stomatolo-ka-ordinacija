using System.Collections.Generic;
using Model;

namespace Services.Zahvati
{
    public interface IZahvatService
    {
        bool SaveZahvat(Zahvat zahvat);
        Zahvat GetZahvat(int id);
        List<Zahvat> GetAllZahvat();
        bool DeleteZahvat(int id);
    }
}
