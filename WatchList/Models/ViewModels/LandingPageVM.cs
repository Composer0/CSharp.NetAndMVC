using System.Collections.Generic;
using WatchList.Models.Database;
using WatchList.Models.TMDB;

namespace WatchList.Models.ViewModels
{
    public class LandingPageVM // This view model is a class that will not be turned into a database. It is meant to aggregate, combine several sources of data into one model. It is a tool of convenience.
    {
        public List<Collection> CustomCollections {get; set;}
        public MovieSearch NowPlaying { get; set; }
        public MovieSearch Popular { get; set; }
        public MovieSearch TopRated { get; set; }
        public MovieSearch Upcoming { get; set; }

    }
}
