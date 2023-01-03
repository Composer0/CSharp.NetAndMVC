using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WatchList.Services.Interfaces
{
    public interface IImageService // Transforming data to be suitable for storing in database. The opposite must occur as well in order to be rendered.
    {
        Task<byte[]> EncodeImageAsync(IFormFile Poster);
        Task<byte[]> EncodeImageURLAsync(string imageURL); //converts into storage for database.
        string DecodeImage(byte[] poster, string contentType); //reads the string and decodes into a byte array.

    }
}
