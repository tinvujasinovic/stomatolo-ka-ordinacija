using Model;
using Services.NarudzbeService;

namespace Services.Narudzbe
{
    public class NarudzbeService : INarudzbeService
    {
        private DbService db = DbService.GetInstance();

        public Narudzba GetNarudzba()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveRadnoVrijeme(Narudzba model)
        {
            throw new System.NotImplementedException();
        }
    }
}