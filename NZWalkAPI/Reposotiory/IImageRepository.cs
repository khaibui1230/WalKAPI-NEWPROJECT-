using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Reposotiory
{
    public interface IImageRepository
    {
        Task<Image> Upload (Image image);
    }
}
