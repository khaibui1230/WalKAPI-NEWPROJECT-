using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Reposotiory
{
    public interface IWalkRepository
    {
        Task<List<Walks>> GetAllAsync();
        Task<Walks?> GetByIdAsync(Guid id);
        Task<Walks> CreateAsync(Walks walks);
        Task<Walks?> UpdateAsync(Guid id, Walks walks);
        Task<Walks?> DeleteAsync(Guid id);
    }
}
