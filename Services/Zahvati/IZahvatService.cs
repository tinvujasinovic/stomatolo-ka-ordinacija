using System.Collections.Generic;
using Model;

namespace Services.Zahvati
{
    public interface IZahvatService
    {
        void SaveZahvat(Zahvat zahvat);
        Zahvat GetZahvat(int id);
        List<Zahvat> GetAllZahvat();
        void DeleteZahvat(int id);
    }
}
