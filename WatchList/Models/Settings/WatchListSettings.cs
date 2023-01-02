using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WatchList.Models.Settings
{
    public class WatchListSettings
    {
        public string TbDbApiKey { get; set; }
        public string DefaultBackdropSize { get; set; }
        public string DefaultPosterSize { get; set; }
        public string DefualtYouTubeKey { get; set; }
        public string DefualtCastImage { get; set; }
        public DefaultCollection DefaultCollection { get; set; }
        public DefaultCredentials DefaultCredentials { get; set; }
    }

    public class DefaultCollection
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DefaultCredentials
    {
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
