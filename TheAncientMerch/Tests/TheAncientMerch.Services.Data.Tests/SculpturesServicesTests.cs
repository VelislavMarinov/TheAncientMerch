namespace TheAncientMerch.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Sculpture;
    using TheAncientMerch.Services.Data.SculptureMaterial;
    using TheAncientMerch.Web.ViewModels.Sculptures;
    using Xunit;

    public class SculpturesServicesTests : BaseServiceTest
    {
        private readonly Mock<IDeletableEntityRepository<Sculpture>> sculptureRepository;
        private readonly Mock<IDeletableEntityRepository<Payment>> paymentRepository;
        private readonly Mock<ISculptureMaterialService> materialService;

        public SculpturesServicesTests()
        {
            this.paymentRepository = new Mock<IDeletableEntityRepository<Payment>>();
            this.sculptureRepository = new Mock<IDeletableEntityRepository<Sculpture>>();
            this.materialService = new Mock<ISculptureMaterialService>();
        }


        [Fact]
        public async Task GetAllSculpturesShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            var material2 = new SculptureMaterial
            {
                Name = "Bronze",
            };
            await db.SculptureMaterials.AddAsync(material);
            await db.SculptureMaterials.AddAsync(material2);
            await db.SaveChangesAsync();


            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            var sculpture2 = new Sculpture
            {
                Id = 2,
                Name = "Woman of Pride2",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 355,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("White"),
                SculptureType = Enum.Parse<SculptureType>("Vases"),
            };

            var sculpture3 = new Sculpture
            {
                Id = 3,
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.Sculptures.AddAsync(sculpture2);
            await db.Sculptures.AddAsync(sculpture3);
            await db.SaveChangesAsync();

            var resultAllSculptures = await sculptureService.GetAllSculptures(1, 3, null, null, null);
            var resultallSculpturesByMaterrial = await sculptureService.GetAllSculptures(1, 3, "Bronze", null, null);

            Assert.True(resultAllSculptures.Sculptures.Count() == 3);
            Assert.Equal(sculpture3.Name, resultAllSculptures.Sculptures.Where(x => x.Id == sculpture3.Id).Select(x => x.Name).FirstOrDefault());
            Assert.True(resultallSculpturesByMaterrial.Sculptures.Count() == 2);
        }

        [Fact]
        public async Task DeleteSculptureAsyncShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var sculptureRepository = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepository, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var sculpture = db.Sculptures.Where(x => x.Id == 1).FirstOrDefault();

            await sculptureService.DeleteSculptureAsync(1);

            var resultSculpture = db.Sculptures.Where(x => x.Id == 1).FirstOrDefault();

            Assert.NotNull(sculpture);
            Assert.Null(resultSculpture);
        }

        [Fact]
        public async Task GetCountsShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var sculptureRepository = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepository, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var result = sculptureService.GetCount();
            Assert.Equal(1, result);
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task ChekIfSculptureIdIsValid()
        {
            ApplicationDbContext db = GetDatabase();

            var sculptureRepository = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepository, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var result = sculptureService.ChekIfSculptureIdIsValid(1);
            var result2 = sculptureService.ChekIfSculptureIdIsValid(2);
            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task GetSculptureForBuyViewModelShouldReturnCorrectSculpture()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            var material2 = new SculptureMaterial
            {
                Name = "Bronze",
            };
            await db.SculptureMaterials.AddAsync(material);
            await db.SculptureMaterials.AddAsync(material2);
            await db.SaveChangesAsync();


            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            var sculpture2 = new Sculpture
            {
                Id = 2,
                Name = "Woman of Pride2",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 355,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("White"),
                SculptureType = Enum.Parse<SculptureType>("Vases"),
            };

            var sculpture3 = new Sculpture
            {
                Id = 3,
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.Sculptures.AddAsync(sculpture2);
            await db.Sculptures.AddAsync(sculpture3);
            await db.SaveChangesAsync();

            var result = sculptureService.GetSculptureForBuyViewModel(3);

            Assert.Equal(sculpture3.Name, result.Name);
        }

        [Fact]
        public async Task GetSculptureByIdShouldReturnCorrectSculpture()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            var material2 = new SculptureMaterial
            {
                Name = "Bronze",
            };
            await db.SculptureMaterials.AddAsync(material);
            await db.SculptureMaterials.AddAsync(material2);
            await db.SaveChangesAsync();


            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            var sculpture2 = new Sculpture
            {
                Id = 2,
                Name = "Woman of Pride2",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 355,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("White"),
                SculptureType = Enum.Parse<SculptureType>("Vases"),
            };

            var sculpture3 = new Sculpture
            {
                Id = 3,
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.Sculptures.AddAsync(sculpture2);
            await db.Sculptures.AddAsync(sculpture3);
            await db.SaveChangesAsync();

            var result = sculptureService.GetSculptureById(2);

            Assert.Equal(sculpture2.Name, result.Name);
        }

        [Fact]
        public async Task GetAllUserSculpturesShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            var material2 = new SculptureMaterial
            {
                Name = "Bronze",
            };
            await db.SculptureMaterials.AddAsync(material);
            await db.SculptureMaterials.AddAsync(material2);
            await db.SaveChangesAsync();


            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            var sculpture2 = new Sculpture
            {
                Id = 2,
                Name = "Woman of Pride2",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 355,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("White"),
                SculptureType = Enum.Parse<SculptureType>("Vases"),
            };

            var sculpture3 = new Sculpture
            {
                Id = 3,
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material2,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.Sculptures.AddAsync(sculpture2);
            await db.Sculptures.AddAsync(sculpture3);
            await db.SaveChangesAsync();

            var result = sculptureService.GetAllUserSculptures("x222");

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task CreateShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var sculputreInputModel = new CreateSculptureInputModel
            {
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                MaterialId = 1,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await sculptureService.Create(sculputreInputModel, "x222");

            var result = db.Sculptures.Where(x => x.Name == sculputreInputModel.Name).FirstOrDefault();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task EditSculptureAsyncShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var materialService = new SculptureMaterialService(materialRepository);

            var sculptureService = new SculptureService(sculptureRepostirory, materialService, this.paymentRepository.Object);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var sculputreEditModel = new EditSculptureViewModel
            {
                Name = "Woman of Pride3",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                MaterialId = 1,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await sculptureService.EditSculptureAsync(sculputreEditModel, 1);

            var result = db.Sculptures.Where(x => x.Id == 1).FirstOrDefault();
            Assert.True(result.Name == sculputreEditModel.Name);
        }
    }
}
