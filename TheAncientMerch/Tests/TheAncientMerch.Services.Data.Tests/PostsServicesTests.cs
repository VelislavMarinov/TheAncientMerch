namespace TheAncientMerch.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Comment;
    using TheAncientMerch.Services.Data.Post;
    using TheAncientMerch.Services.Mapping;
    using TheAncientMerch.Web.ViewModels.Posts;
    using Xunit;

    public class PostsServicesTests : BaseServiceTest
    {
        private readonly Mock<IDeletableEntityRepository<Post>> postsRepository;
        private readonly Mock<IDeletableEntityRepository<ForumCategory>> forumCategoriesRepository;
        private readonly Mock<IDeletableEntityRepository<ApplicationUser>> usersRepository;
        private readonly Mock<IDeletableEntityRepository<Comment>> commentsRepository;

        public PostsServicesTests()
        {
            this.forumCategoriesRepository = new Mock<IDeletableEntityRepository<ForumCategory>>();
            this.postsRepository = new Mock<IDeletableEntityRepository<Post>>();
            this.usersRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.commentsRepository = new Mock<IDeletableEntityRepository<Comment>>();
        }

        [Fact]
        public async Task GetPostByIdShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var commentsRepository = new EfDeletableEntityRepository<Comment>(db);

            var postService = new PostService(this.forumCategoriesRepository.Object, postsRepository, this.usersRepository.Object, commentsRepository);

            var user = new ApplicationUser
            {
                Id = "2x4",
                UserName = "Pesho",
                Email = "pesho@pesho.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var forumCategory1 = new ForumCategory
            {
                Name = "Test1",
                AddedByUserId = "2x=4",
                Description = "TestTestTest",
            };

            await db.ForumCategories.AddAsync(forumCategory1);
            await db.SaveChangesAsync();

            var post1 = new Post
            {
                Id = 3,
                Title = "TestTitle1",
                Content = "Content.....",
                Category = forumCategory1,
                AddedByUserId = "2x4",
                CategoryId = 1,
            };

            await db.Posts.AddAsync(post1);
            await db.SaveChangesAsync();

            var comment = new Comment
            {
                Id = 1,
                AddedByUserId = "2x4",
                Content = "hello",
                PostId = 3,
                AddedByUser = user,
            };

            await db.Comments.AddAsync(comment);
            await db.SaveChangesAsync();

            var result = postService.GetPostById(3).Title;

            Assert.True(result != null);
        }

        [Fact]
        public void GetForumCategories()
        {
            ApplicationDbContext db = GetDatabase();

            var forumCategoriesRepository = new EfDeletableEntityRepository<ForumCategory>(db);

            var postService = new PostService(forumCategoriesRepository, this.postsRepository.Object, this.usersRepository.Object, this.commentsRepository.Object);

            var forumCategory1 = new ForumCategory
            {
                Name = "Test1",
                AddedByUserId = "1x23",
                Description = "TestTestTest",
            };

            var forumCategory2 = new ForumCategory
            {
                Name = "Test2",
                AddedByUserId = "1x23",
                Description = "TestTestTest",
            };

            var forumCategory3 = new ForumCategory
            {
                Name = "Test3",
                AddedByUserId = "1x23",
                Description = "TestTestTest",
            };

            db.ForumCategories.Add(forumCategory1);
            db.ForumCategories.Add(forumCategory2);
            db.ForumCategories.Add(forumCategory3);
            db.SaveChanges();

            var result = postService.GetForumCategories().Count();

            Assert.Equal(3, result);
        }

        [Fact]
        public async Task CreatePostAsyncShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDatabase();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var postService = new PostService(this.forumCategoriesRepository.Object, postsRepository, this.usersRepository.Object, this.commentsRepository.Object);

            var model = new CreatePostsInputViewModel
            {
                Title = "Title",
                Content = "Content...",
                CategoryId = 1,
            };

            var result = await postService.CreatePostAsync(model, "123");

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeletePostAsync()
        {
            ApplicationDbContext db = GetDatabase();

            var postsRepository = new EfDeletableEntityRepository<Post>(db);

            var postService = new PostService(this.forumCategoriesRepository.Object, postsRepository, this.usersRepository.Object, this.commentsRepository.Object);

            var user = new ApplicationUser
            {
                Id = "2x=4",
                UserName = "Pesho",
                Email = "pesho@pesho.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var forumCategory1 = new ForumCategory
            {
                Name = "Test1",
                AddedByUserId = "2x=4",
                Description = "TestTestTest",
            };

            await db.ForumCategories.AddAsync(forumCategory1);
            await db.SaveChangesAsync();

            var post1 = new Post
            {
                Id = 1,
                Title = "TestTitle1",
                Content = "Content.....",
                Category = forumCategory1,
                AddedByUserId = "x222",
            };

            var post2 = new Post
            {
                Id = 2,
                Title = "TestTitle2",
                Content = "Content4.....",
                Category = forumCategory1,
                AddedByUserId = "x222",
            };

            await db.Posts.AddAsync(post1);
            await db.Posts.AddAsync(post2);
            await db.SaveChangesAsync();

            await postService.DeletePostAsync(2);
            Assert.True(db.Posts.Count() == 1);
        }
    }
}
