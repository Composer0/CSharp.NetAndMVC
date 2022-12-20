// This file does not have the I for interface because it implements the interface.

using ContactPro.Services.Interfaces;

namespace ContactPro.Services
{
    public class ImageService : IImageService
    {
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" }; // these describe the potential byte arrays.
        private readonly string defaultImage = "img/DefaultContactImage.png";
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
