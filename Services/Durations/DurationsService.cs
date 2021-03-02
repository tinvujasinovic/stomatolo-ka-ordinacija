using Model;
using System.Collections.Generic;

namespace Services.Durations
{
    public class DurationsService : IDurationsService
    {
        private DbService db = DbService.GetInstance();

        public List<Duration> GetAllDurations()
        {
            return db.GetAllDurations();
        }
    }
}
