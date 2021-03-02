using Model;
using System.Collections.Generic;

namespace Services.Durations
{
    public interface IDurationsService
    {
        List<Duration> GetAllDurations();
    }
}
