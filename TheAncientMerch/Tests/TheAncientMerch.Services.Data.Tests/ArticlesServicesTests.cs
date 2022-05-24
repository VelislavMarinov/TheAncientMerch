namespace TheAncientMerch.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Article;

    using Xunit;

    public class ArticlesServicesTests : BaseServiceTest
    {
        [Fact]
        public async Task GetAllCategoriesShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var articleService = new ArticleService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Games",
                ImageUrl = "TestUrl",
            };

            var articleCategory2 = new ArticleCategory
            {
                Id = 2,
                Name = "Demigods",
                ImageUrl = "TestUrl",
            };

            var articleCategory3 = new ArticleCategory
            {
                Id = 3,
                Name = "Monsters",
                ImageUrl = "TestUrl",
            };

            var articleCategory4 = new ArticleCategory
            {
                Id = 4,
                Name = "Monsters2",
                ImageUrl = "TestUrl",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.ArticleCategories.AddAsync(articleCategory2);
            await db.ArticleCategories.AddAsync(articleCategory3);
            await db.ArticleCategories.AddAsync(articleCategory4);
            await db.SaveChangesAsync();

            var result = articleService.GetAllCategories();

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async Task GetAllArticlesShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var articleService = new ArticleService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Games",
                ImageUrl = "TestUrl",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = "a223",
                UserName = "pesho",
                Email = "pesho@mail.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var article = new Article
            {
                Id = 1,
                Title = "Smite",
                Content = "Smite is the best game.",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "God of war 3",
                Content = "God of war 3 is a good game",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            var article3 = new Article
            {
                Id = 3,
                Title = "Hades",
                Content = "Hades is a good game",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            await db.Articles.AddAsync(article);
            await db.Articles.AddAsync(article2);
            await db.Articles.AddAsync(article3);
            await db.SaveChangesAsync();

            var result = articleService.GetAllArticles(1, 3);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetArticleByIdShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDatabase();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var articleService = new ArticleService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Games",
                ImageUrl = "TestUrl",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = "a223",
                UserName = "pesho",
                Email = "pesho@mail.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var article = new Article
            {
                Id = 1,
                Title = "Smite",
                Content = "Smite is the best game.",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Hades",
                Content = "Hades is the new..",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            await db.Articles.AddAsync(article);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var result = articleService.GetArticleById(2);

            Assert.Equal(article2.Title, result.Title);
        }

        [Fact]
        public async Task GetArticleByCategoryIdShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDatabase();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var articleService = new ArticleService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Games",
                ImageUrl = "TestUrl",
            };

            var articleCategory2 = new ArticleCategory
            {
                Id = 2,
                Name = "Demigods",
                ImageUrl = "TestUrl",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.ArticleCategories.AddAsync(articleCategory2);
            await db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = "a223",
                UserName = "pesho",
                Email = "pesho@mail.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var article = new Article
            {
                Id = 1,
                Title = "Smite",
                Content = "Smite is the best game.",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "God of war 3",
                Content = "God of war 3 is a good game",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "TestUrl",
            };

            var article3 = new Article
            {
                Id = 3,
                Title = "Hades",
                Content = "Hades is a good game",
                AddedByUser = user,
                CategoryId = 2,
                ImageUrl = "TestUrl",
            };

            await db.Articles.AddAsync(article);
            await db.Articles.AddAsync(article2);
            await db.Articles.AddAsync(article3);
            await db.SaveChangesAsync();

            var result = articleService.GetArticlesByCategoryId(1);

            var resultWithDifferentCategory = articleService.GetArticlesByCategoryId(2);

            Assert.Equal(2, result.Count());
            Assert.Equal(article.Title, result.Where(x => x.Title == article.Title).Select(x => x.Title).FirstOrDefault());
            Assert.Single(resultWithDifferentCategory);
            Assert.Equal(article3.Title, resultWithDifferentCategory.Where(x => x.Title == article3.Title).Select(x => x.Title).FirstOrDefault());
        }

        [Fact]
        public async Task DeleteArticleShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var articleCategoryRepository = new EfDeletableEntityRepository<ArticleCategory>(db);
            var articleRepository = new EfDeletableEntityRepository<Article>(db);

            var articleService = new ArticleService(articleCategoryRepository, articleRepository);

            var articleCategory = new ArticleCategory
            {
                Id = 1,
                Name = "Fitness",
                ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
            };

            await db.ArticleCategories.AddAsync(articleCategory);
            await db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = "a223",
                UserName = "pesho",
                Email = "pesho@mail.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var article1 = new Article
            {
                Id = 1,
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat ....",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            var article2 = new Article
            {
                Id = 2,
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets ...",
                AddedByUser = user,
                CategoryId = 1,
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            };

            await db.Articles.AddAsync(article1);
            await db.Articles.AddAsync(article2);
            await db.SaveChangesAsync();

            var countBeforeDeletion = db.Articles.Count();

            await articleService.DeleteArticleAsync(1);

            var countAfterDeletion = db.Articles.Count();

            Assert.Equal(2, countBeforeDeletion);
            Assert.Equal(1, countAfterDeletion);
        }
    }
}