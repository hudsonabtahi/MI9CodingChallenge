using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI9Challenge.Models
{
    //Model for the service request
    public class FilterShowResponse
    {
        public List<ShowSummary> response{get;set;}
    }
    public class ShowSummary
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }
}