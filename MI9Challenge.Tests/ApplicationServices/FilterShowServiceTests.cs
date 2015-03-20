using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MI9Challenge.ApplicationServices;
using System.Collections.Generic;

namespace MI9Challenge.Tests.ApplicationServices
{
    [TestClass]
    public class FilterShowServiceTests
    {
        
        [TestMethod]
        public void TestFilterDRMMinimumEpisodeCount()
        {
            FilterShowService service = new FilterShowService();

            var result = service.FilterDRMMinimumEpisodeCount(SetupShowList(),true,0);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("drmWithEpisodes",result[0].title);
        }
        private List<Models.Show> SetupShowList()
        {
            var showList = new List<Models.Show>();
            showList.Add(new Models.Show()
                {
                    drm = false,
                    episodeCount = 2,
                    title = "title1"
                });
            showList.Add(new Models.Show()
            {
                drm = true,
                episodeCount = 2,
                title = "drmWithEpisodes"
            });
            showList.Add(new Models.Show()
            {
                drm = true,
                episodeCount = 0,
                title = "title1"
            });
            showList.Add(new Models.Show()
            {
                drm = true,
                episodeCount = -1,
                title = "title1"
            });
            return showList;
        }
    }

}
