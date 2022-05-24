namespace TheAncientMerch.Services.Data.Tests
{
    using System.Linq;

    using Moq;
    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Forum;
    using TheAncientMerch.Web.ViewModels.Forum;
    using Xunit;

    public class ForumServicesTests : BaseServiceTest
    {
        private readonly Mock<IDeletableEntityRepository<ForumCategory>> forumCategoryRepository;
        private readonly Mock<IDeletableEntityRepository<Post>> postRepository;

        public ForumServicesTests()
        {
            this.forumCategoryRepository = new Mock<IDeletableEntityRepository<ForumCategory>>();
            this.postRepository = new Mock<IDeletableEntityRepository<Post>>();
        }

        [Fact]
        public void CreateCategoryAsyncShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var postRepository = new EfDeletableEntityRepository<Post>(db);

            var forumService = new ForumService(forumCategoryRepository, postRepository);

            var category = new CreateForumInputViewModel
            {
                Name = "Games",
                Description = "TestDescription",
            };

            var create = forumService.CreateCategoryAsync(category, "x222");

            var result = forumCategoryRepository.All().Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAllCategoriesShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDatabase();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var postRepository = new EfDeletableEntityRepository<Post>(db);

            var forumService = new ForumService(forumCategoryRepository, postRepository);

            var category = new ForumCategory
            {
                Id = 1,
                Name = "I love hades",
                Description = "TestDesciption",
                AddedByUserId = "x222",
            };

            var category2 = new ForumCategory
            {
                Id = 2,
                Name = "I hate god of war and you cant change mi mind",
                Description = "TestDesciption",
                AddedByUserId = "x222",
            };

            var category3 = new ForumCategory
            {
                Id = 3,
                Name = "I love god of war and you cant change mi mind",
                Description = "TestDesciption",
                AddedByUserId = "x222",
            };

            db.ForumCategories.Add(category);
            db.ForumCategories.Add(category2);
            db.SaveChanges();

            var result = forumService.GetAllCategories();

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void GetCategoryByNameShouldReturnCorectResult()
        {
            ApplicationDbContext db = GetDatabase();

            var forumCategoryRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var postRepository = new EfDeletableEntityRepository<Post>(db);

            var forumService = new ForumService(forumCategoryRepository, postRepository);

            var category = new ForumCategory
            {
                Id = 1,
                Name = "I love hades",
                Description = "TestDesciption",
                AddedByUserId = "x222",
            };

            var category2 = new ForumCategory
            {
                Id = 2,
                Name = "I hate god of war and you cant change mi mind",
                Description = "TestDesciption",
                AddedByUserId = "x222",
            };

            db.ForumCategories.Add(category);
            db.ForumCategories.Add(category2);
            db.SaveChanges();

            var result = forumService.GetCategoryByName(category.Name);

            Assert.Equal(category.Name, result.Name);
        }
    }
}
