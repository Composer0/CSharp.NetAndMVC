using System.Collections;
using System.Collections.Generic;

namespace WatchList.Models.Database
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<MovieCollection> MovieCollections { get; set; } = new HashSet<MovieCollection>(); //Navigation to combine and initialize this with the Movie model into the Movie Collection model.
    }
}
