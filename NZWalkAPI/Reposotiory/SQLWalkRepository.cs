using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Data;
using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Reposotiory
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walks> CreateAsync(Walks walks)
        {
            var newWalk = new Walks()
            {
                Id = Guid.NewGuid(),
                Name = walks.Name,
                LengthInKm = walks.LengthInKm,
                Description = walks.Description,
                WalkImageUrl = walks.WalkImageUrl,
                RegionId = walks.RegionId,
                DifficultyId = walks.DifficultyId
            };

            await dbContext.Walks.AddAsync(newWalk);
            await dbContext.SaveChangesAsync();
            return newWalk;
        }

        public async Task<Walks?> DeleteAsync(Guid id)
        {
            var existingWalk =await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk != null)
            {
                dbContext.Walks.Remove(existingWalk);
                await dbContext.SaveChangesAsync();

                return existingWalk;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Walks>> GetAllAsync()
        {
            return await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.Difficulty)
                .ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.Difficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walks)
        {
            var existingWalk =await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk != null)
            {
                existingWalk.Name = walks.Name;
                existingWalk.LengthInKm = walks.LengthInKm;
                existingWalk.Description = walks.Description;
                existingWalk.WalkImageUrl = walks.WalkImageUrl;
                existingWalk.RegionId = walks.RegionId;
                existingWalk.DifficultyId = walks.DifficultyId;
                await dbContext.SaveChangesAsync();
                // Return the updated walk
                return existingWalk;
            }
            else
            {
                return null;
            }
        }
    }
}
