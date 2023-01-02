

namespace WatchList.Models.Settings
{
    public class AppSettings
    {
        public WatchListSettings WatchListSettings { get; set; } //property name should mimic clas sname.
        public TMDBSettings TMDBSettings { get; set; }
    }
}
