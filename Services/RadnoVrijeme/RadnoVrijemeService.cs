using Model;
using System;
using System.Collections.Generic;

namespace Services.RadnoVrijeme
{
    public class RadnoVrijemeService : IRadnoVrijemeService
    {
        private DbService db = DbService.GetInstance();

        public Model.RadnoVrijeme GetRadnoVrijeme()
        {
            return db.GetRadnoVrijeme();
        }

        public bool SaveRadnoVrijeme(Model.RadnoVrijeme model)
        {
            return db.SaveRadnoVrijeme(model);
        }
    }
}
