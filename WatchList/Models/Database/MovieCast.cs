namespace WatchList.Models.Database
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //Foreign Key
        public int CastID { get; set; } //Info based on TMDB for api purpose.
        public string Department { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ImageUrl { get; set; } //stores the full path to the online image for the cast member.
        public Movie Movie { get; set; }
    }
}
