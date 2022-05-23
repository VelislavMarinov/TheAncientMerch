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
    using TheAncientMerch.Services.Data.Search;
    using Xunit;

    public class SearchServicesTests : BaseServiceTest
    {
        private readonly Mock<IDeletableEntityRepository<Sculpture>> sculptureRepository;
        private readonly Mock<IRepository<GreekDeity>> deitiesRepository;
        private readonly Mock<IDeletableEntityRepository<Article>> articleRepository;

        public SearchServicesTests()
        {
            this.sculptureRepository = new Mock<IDeletableEntityRepository<Sculpture>>();
            this.deitiesRepository = new Mock<IRepository<GreekDeity>>();
            this.articleRepository = new Mock<IDeletableEntityRepository<Article>>();
        }

        [Fact]
        public async Task SearchArticleByKeywordShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var articleRepository = new EfDeletableEntityRepository<Article>(db);
            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);

            var searchService = new SearchService(this.sculptureRepository.Object, articleRepository, this.deitiesRepository.Object);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Games",
                ImageUrl = "randomUrl",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@pesho.com",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var article1 = new Article
            {
                Id = 1,
                Title = "Achilies love",
                Content = "I love programing",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "randomUrl",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Hercules love",
                Content = "If you see this i like you <3",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "randomUrl",
            };

            var article3 = new Article
            {
                Id = 3,
                Title = "Medusa hate",
                Content = "You are the best teacher outh there Nikolai!",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "randomUrl",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.Articles.AddAsync(article3);
            await db.SaveChangesAsync();

            var result = searchService.SearchArticleByKeyword("Hercules");
            var resultForMutipleArticles = searchService.SearchArticleByKeyword("love");

            Assert.Single(result);
            Assert.Equal(2,resultForMutipleArticles.Count());
            Assert.Equal(result.First().Title, article2.Title);
        }

        [Fact]
        public async Task SearcSculptureByKeywordShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var sculptureRepository = new EfDeletableEntityRepository<Sculpture>(db);
            var materialRepository = new EfRepository<SculptureMaterial>(db);
            var searchService = new SearchService(sculptureRepository, this.articleRepository.Object, this.deitiesRepository.Object);

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

            var sculpture2 = new Sculpture
            {
                Id = 2,
                Name = "Emperor Julius",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 355,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("White"),
                SculptureType = Enum.Parse<SculptureType>("Vases"),
            };

            var sculpture3 = new Sculpture
            {
                Id = 3,
                Name = "No Name",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 400,
                Height = 24.50M,
                Width = 10,
                Weigth = 12,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Green"),
                SculptureType = Enum.Parse<SculptureType>("Busts"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.Sculptures.AddAsync(sculpture2);
            await db.Sculptures.AddAsync(sculpture3);
            await db.SaveChangesAsync();

            var result = searchService.SearcSculptureByKeyword("No");
            var resultForMutipleSculptures = searchService.SearcSculptureByKeyword("o");

            Assert.Single(result);
            Assert.Equal(3, resultForMutipleSculptures.Count());
            Assert.Equal(result.First().Name, sculpture3.Name);
        }

        [Fact]
        public async Task SearchGreekDeityByUsernameShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var deitiesRepository = new EfRepository<GreekDeity>(db);

            var searchService = new SearchService(this.sculptureRepository.Object, this.articleRepository.Object, deitiesRepository);

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
                Name = "Zeus",
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
                Name = "Cronus",
                ImageUrl = "https://i.pinimg.com/originals/93/13/7e/93137eb35a1eff0bdf785a1b1a294837.jpg",
                Description = "Hello i am poseidon god of the oceans",
                VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                Type = Enum.Parse<DeityType>("Titan"),
            };

            await db.GreekDeities.AddAsync(deity);
            await db.GreekDeities.AddAsync(deity2);
            await db.GreekDeities.AddAsync(deity3);
            await db.GreekDeities.AddAsync(deity4);
            await db.SaveChangesAsync();

            var result = searchService.SearchGreekDeityByUsername("Cronus");
            var resultWithWrongName = searchService.SearchGreekDeityByUsername("d");

            Assert.Equal(result.Name, deity4.Name);
            Assert.Null(resultWithWrongName);
        }
    }
}
