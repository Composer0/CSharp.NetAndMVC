namespace WatchList.Models.Database
{
    public class MovieCollection
    {
        public int Id { get; set; } //Primary key for this model.
        public int CollectionId { get; set; } //Foreign Key that points to primary key in Collection Model
        public int MovieId { get; set; } //Foreign Key that points to primary key in Movie Model

        public int Order { get; set; } //Descriptive Property. This is used to help prioritize the order films.

        public Collection Collection { get; set; } //Navigation Property
        public Movie Movie { get; set; } //Navigation Property
    }
}
