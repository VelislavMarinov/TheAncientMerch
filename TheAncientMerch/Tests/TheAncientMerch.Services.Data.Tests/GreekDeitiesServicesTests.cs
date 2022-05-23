namespace TheAncientMerch.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.GreekDeity;
    using Xunit;

    public class GreekDeitiesServicesTests : BaseServiceTest
    {
        [Fact]
        public async Task GetAllGodsShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var deitiesRepository = new EfRepository<GreekDeity>(db);

            var deitiesService = new GreekDeityService(deitiesRepository);

            var deity = new GreekDeity
            {
                Name = "Poseidon",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            var deity2 = new GreekDeity
            {
                Name = "Poseidon2",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            var deity3 = new GreekDeity
            {
                Name = "Atlas",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            var deity4 = new GreekDeity
            {
                Name = "Poseidon4",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            await db.GreekDeities.AddAsync(deity);
            await db.GreekDeities.AddAsync(deity2);
            await db.GreekDeities.AddAsync(deity3);
            await db.GreekDeities.AddAsync(deity4);
            await db.SaveChangesAsync();

            var result = deitiesService.GetAllGods().Count();

            Assert.Equal(3, result);
        }

        [Fact]
        public async Task GetAllTitansShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var deitiesRepository = new EfRepository<GreekDeity>(db);

            var deitiesService = new GreekDeityService(deitiesRepository);

            var deity = new GreekDeity
            {
                Name = "Poseidon",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            var deity2 = new GreekDeity
            {
                Name = "Poseidon2",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            var deity3 = new GreekDeity
            {
                Name = "Gaia",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            var deity4 = new GreekDeity
            {
                Name = "Zeus",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            await db.GreekDeities.AddAsync(deity);
            await db.GreekDeities.AddAsync(deity2);
            await db.GreekDeities.AddAsync(deity3);
            await db.GreekDeities.AddAsync(deity4);
            await db.SaveChangesAsync();

            var result = deitiesService.GetAllTitans().Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetDeity()
        {
            ApplicationDbContext db = GetDatabase();

            var deitiesRepository = new EfRepository<GreekDeity>(db);

            var deitiesService = new GreekDeityService(deitiesRepository);

            var deity = new GreekDeity
            {
                Id = 1,
                Name = "Poseidon",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            var deity2 = new GreekDeity
            {
                Id = 2,
                Name = "Poseidon2",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            var deity3 = new GreekDeity
            {
                Id = 3,
                Name = "Gaia",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            var deity4 = new GreekDeity
            {
                Id = 4,
                Name = "Zeus",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("God"),
            };

            await db.GreekDeities.AddAsync(deity);
            await db.GreekDeities.AddAsync(deity2);
            await db.GreekDeities.AddAsync(deity3);
            await db.GreekDeities.AddAsync(deity4);
            await db.SaveChangesAsync();

            var result = deitiesService.GetDeity(3);
            var result2 = deitiesService.GetDeity(2);

            Assert.Equal(deity3.Description, result.Description);
            Assert.Equal(deity2.Description, result2.Description);
        }
    }
}
