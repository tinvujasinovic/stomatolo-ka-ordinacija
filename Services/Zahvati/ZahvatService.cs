using Model;
using System.Collections.Generic;

namespace Services.Zahvati
{
    public class ZahvatService : IZahvatService
    {
        private DbService db = DbService.GetInstance();

        public ZahvatService(){}

        public void DeleteZahvat(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Zahvat> GetAllZahvat()
        {
            throw new System.NotImplementedException();
        }

        public Zahvat GetZahvat(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveZahvat(Zahvat zahvat)
        {
            db.SaveZahvat(zahvat);
        }
    }
}
