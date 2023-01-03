using System.Threading.Tasks;
using WatchList.Models.Database;
using WatchList.Models.TMDB;

namespace WatchList.Services.Interfaces
{
    public interface IDataMappingService // This new interface will only concern itself with the data coming from the API.
    {
        Task<Movie> MapMovieDetailAsync(MovieDetail movie); //Notice the word map Orion ;)
        ActorDetail MapActorDetailAsync(ActorDetail actorDetail);

    }
}
