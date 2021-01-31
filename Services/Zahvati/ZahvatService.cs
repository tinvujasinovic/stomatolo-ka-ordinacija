using Model;
using System.Collections.Generic;

namespace Services.Zahvati
{
    public class ZahvatService : IZahvatService
    {
        private DbService db = DbService.GetInstance();

        public ZahvatService(){}

        public bool DeleteZahvat(int id)
        {
            return db.DeleteZahvat(id);
        }

        public List<Zahvat> GetAllZahvat()
        {
            return db.GetAllZahvat();
        }

        public Zahvat GetZahvat(int id)
        {
            return db.GetZahvat(id);
        }

        public bool SaveZahvat(Zahvat zahvat)
        {
            return db.SaveZahvat(zahvat);
        }
    }
}
