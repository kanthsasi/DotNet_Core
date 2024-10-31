using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using NZWalks.API.Domain;


namespace NZWalks.API.Data
{
    public class NZWalksDBContext:DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        //Start from Section-5

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for difficulty
            //Easy,Medium,Hard

            var difficulties = new List<Difficulty>()
            {
               new Difficulty()
               {
                   Id=Guid.Parse("b2fb70a3-e378-4f10-9878-131d231f9a39"),
                   Name="Easy"
               },
               new Difficulty()
               {
                   Id=Guid.Parse("c0c25a30-94a0-4816-b1c2-e63fdbbc285d"),
                   Name="Medium"
               },
               new Difficulty()
               {
                   Id=Guid.Parse("b4e08474-bfe6-4de0-ba61-6e9d4196490a"),
                   Name="Hard"
               }
            };
            //Seed difficulties to the databae.
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Region.
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("b509ff86-1133-4f64-b3db-eff41651d55f"),
                    Name="Huckland",
                    Code="HKL",
                    RegionImageUrl=null
                },
                 new Region()
                {
                    Id=Guid.Parse("ef5cefa8-c72c-4bc5-8d7c-3c9ee0015589"),
                    Name="Northland",
                    Code="NTL",
                    RegionImageUrl=null
                },
                  new Region()
                {
                    Id=Guid.Parse("856e83a2-467f-4f87-b151-0b4bae97c3db"),
                    Name="Bay Of Plenty",
                    Code="BOP",
                    RegionImageUrl=null
                },
                   new Region()
                {
                    Id=Guid.Parse("adc2a3f2-8b25-43d0-ac25-6a9c752ec7e5"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl=null
                },
                    new Region()
                {
                    Id=Guid.Parse("5611634b-5000-4e7b-89df-26eaf6bb9eb3"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl=null
                },
                     new Region()
                {
                    Id=Guid.Parse("49382892-b872-4f16-8b31-8f8a8f409cb5"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl=null
                },
                 
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}

