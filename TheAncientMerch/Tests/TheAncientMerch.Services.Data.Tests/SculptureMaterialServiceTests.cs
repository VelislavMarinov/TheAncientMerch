namespace TheAncientMerch.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.SculptureMaterial;
    using Xunit;

    public class SculptureMaterialServiceTests : BaseServiceTest
    {
        [Fact]
        public async Task GetAllMaterialsShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var sculptureMaterialRepository = new EfRepository<SculptureMaterial>(db);

            var sculptureMaterialServices = new SculptureMaterialService(sculptureMaterialRepository);

            var sculptureMaterial = new SculptureMaterial
            {
                Name = "Marble",
                Id = 1,
            };

            var sculptureMaterial2 = new SculptureMaterial
            {
                Name = "bronze",
                Id = 2,
            };

            await db.SculptureMaterials.AddAsync(sculptureMaterial);
            await db.SculptureMaterials.AddAsync(sculptureMaterial2);
            await db.SaveChangesAsync();

            var result = sculptureMaterialServices.GetAllMaterials().Count();

            Assert.True(result == 2);
        }
    }
}
