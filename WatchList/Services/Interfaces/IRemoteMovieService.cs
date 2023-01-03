using System.Threading.Tasks;
using WatchList.Enums;
using WatchList.Models.TMDB;

namespace WatchList.Services.Interfaces
{
    public interface IRemoteMovieService
    {
        Task<MovieDetail> MovieDetailAsync(int id);
        Task<MovieSearch> MovieSearchAsync(MovieCategory category, int count);
        Task<ActorDetail> ActorDetailAsync(int id);
    }
}

//loose coupling is a practice that is preferred because if one class is changed it will not affect another class. Tight coupling is the opposite and is not considered as well designed. Loose coupling makes debugging easier as well as you can find the source of the problem and not everything in the application or multiple parts will fall apart if something goes wrong.