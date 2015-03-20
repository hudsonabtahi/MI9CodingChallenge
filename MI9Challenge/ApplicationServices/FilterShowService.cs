using MI9Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI9Challenge.ApplicationServices
{
    public class FilterShowService : IFilterShowService
    {
        //Service to filter list of shows based on the values of DRM and Episode Count
        //TODO: More generic filtering service 
        public List<Models.ShowSummary> FilterDRMMinimumEpisodeCount(List<Models.Show> showList, bool drmEnabled, int minimumEpisodeCount)
        {

            //Filter and convert the result to List of ShowSummary 
            var filteredShowList = from show in
                                       showList.Where(a => a.drm == drmEnabled && a.episodeCount > minimumEpisodeCount).ToList()
                                   select new ShowSummary()
                                   {
                                       image = show.image != null ? show.image.showImage : null,
                                       slug = show.slug,
                                       title = show.title
                                   };
            var result = filteredShowList.ToList();

            return result;
        }
    }
}