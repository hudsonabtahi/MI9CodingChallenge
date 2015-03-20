using MI9Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI9Challenge.ApplicationServices
{
    public interface IFilterShowService
    {
        List<ShowSummary> FilterDRMMinimumEpisodeCount(List<Show> showList, bool drmEnabled, int minimumEpisodeCount);
    }
}
