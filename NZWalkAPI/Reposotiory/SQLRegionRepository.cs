using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Data;
using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Reposotiory
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion =  await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion != null)
            {
               dbContext.Regions.Remove(existingRegion);
               await dbContext.SaveChangesAsync();
                return existingRegion;
            }
            else
            {
                throw new Exception("Region not found");
            }
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion =  await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion != null)
            {
                existingRegion.Name = region.Name;
                existingRegion.Code = region.Code;
                existingRegion.RegionImageUrl = region.RegionImageUrl;
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
            else
            {
                throw new Exception("Region not found");
            }
        }
    }
}
