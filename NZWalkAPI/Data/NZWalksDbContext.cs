using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        // create the tables in the database
        public DbSet<Walks> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        // Seed the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the database with initial data
            // Seed Difficulties
            var difficultyList = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("364e2e8e-8027-4beb-9775-405545997ef0"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a7110a23-5740-48a1-b018-89e8d47fc5f5"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("12881f7c-b772-46a3-a84e-142dc16104c7"),
                    Name = "Hard",
                }
            };

            // Seed difficulty data into the database
            modelBuilder.Entity<Difficulty>().HasData(difficultyList);


            // Seed Regions
            var regionsList = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("c0f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"),
                    Name = "Northland",
                    Code = "NTH",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Northland_region_map.png/800px-Northland_region_map.png"
                },
                new Region
                {
                    Id = Guid.Parse("d1f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Auckland_region_map.png/800px-Auckland_region_map.png"
                },
                new Region
                {
                    Id = Guid.Parse("e2f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"),
                    Name = "Waikato",
                    Code = "WAI",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Waikato_region_map.png/800px-Waikato_region_map.png"
                }
            };

            modelBuilder.Entity<Region>().HasData(regionsList);

            // Seed Walks
            // Seed Walks
            var walksList = new List<Walks>()
{
    new Walks
    {
        Id = Guid.Parse("f3f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"),
        Name = "Cape Reinga Walk",
        Description = "A scenic walk to the northernmost point of New Zealand.",
        LengthInKm = 10.5,
        WalkImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Cape_Reinga_Walk.png/800px-Cape_Reinga_Walk.png",
        DifficultyId = Guid.Parse("364e2e8e-8027-4beb-9775-405545997ef0"),
        RegionId = Guid.Parse("c0f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e")
    },
    new Walks
    {
        Id = Guid.Parse("aa0d1b17-5f27-4bde-81d1-905e0e7f23b0"),
        Name = "Sky Tower Walk",
        Description = "A walk around the iconic Sky Tower in Auckland.",
        LengthInKm = 5.0,
        WalkImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sky_Tower_Walk.png/800px-Sky_Tower_Walk.png",
        DifficultyId = Guid.Parse("12881f7c-b772-46a3-a84e-142dc16104c7"),
        RegionId = Guid.Parse("d1f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e")
    },
    new Walks
    {
        Id = Guid.Parse("bbf9e091-1e43-48ab-b83f-5094e8b222c3"),
        Name = "Huka Falls Walk",
        Description = "A walk to the stunning Huka Falls in Taupo.",
        LengthInKm = 8.0,
        WalkImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Huka_Falls_Walk.png/800px-Huka_Falls_Walk.png",
        DifficultyId = Guid.Parse("a7110a23-5740-48a1-b018-89e8d47fc5f5"),
        RegionId = Guid.Parse("e2f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e")
    }
};

            modelBuilder.Entity<Walks>().HasData(walksList);

        }
    }
}
