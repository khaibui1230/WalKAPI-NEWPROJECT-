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
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<List<Walks>> GetAllAsync(string? filterOn = null
            , string? filterQuery = null
            ,string? sortBy = null
            ,bool isAscending = true
            ,int pageNumber = 1,
            int pageSize = 10)
        {
            var walksQuery = dbContext.Walks
                .Include(x => x.Difficulty)
                .Include(x => x.Region)
                .AsQueryable();

            // Filtering logic
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = walksQuery.Where(x => x.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = walksQuery.Where(x => x.Description.Contains(filterQuery));
                }
            }

            // Sorting logic
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = isAscending 
                        ? walksQuery.OrderBy(x => x.Name) 
                        : walksQuery.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = isAscending 
                        ? walksQuery.OrderBy(x => x.LengthInKm) 
                        : walksQuery.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagination logic
            var skipResults = (pageNumber - 1) * pageSize;
            walksQuery = walksQuery.Skip(skipResults).Take(pageSize);

            // Execute the query and return the results
            return await walksQuery.ToListAsync();

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
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

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
