namespace TheAncientMerch.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Comment;
    using TheAncientMerch.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsServicesTests : BaseServiceTest
    {
        [Fact]
        public async Task CreateCommentShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var comentService = new CommentService(commentRepository);

            var user = new ApplicationUser
            {
                Id = "222x",
                UserName = "pesho",
                Email = "pesho@email.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var category = new ForumCategory
            {
                Id = 1,
                Name = "Games",
                Description = "TestDescription",
                AddedByUserId = "222x",
            };

            await db.ForumCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var post = new Post
            {
                Id = 1,
                Title = "Some post title",
                Content = "Some content....",
                AddedByUserId = user.Id,
                CategoryId = 1,
            };
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();

            var model = new CreateCommentInputViewModel
            {
                PostId = 1,
                Content = "Content good very good",
            };

            var resultWithNoComment = db.Posts.Where(x => x.Id == 1).FirstOrDefault().Comments.Count();

            var createComent = comentService.CreateCommentAsync(model, user.Id, post.Id);

            var resultWithCreatedComent = db.Posts.Where(x => x.Id == 1).FirstOrDefault().Comments.Count();

            Assert.Equal(0, resultWithNoComment);
            Assert.Equal(1, resultWithCreatedComent);
        }

        [Fact]
        public async Task DeleteCommentShouldDeleteComment()
        {
            ApplicationDbContext db = GetDatabase();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var comentService = new CommentService(commentRepository);

            var user = new ApplicationUser
            {
                Id = "222x",
                UserName = "pesho",
                Email = "pesho@email.gg",
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var category = new ForumCategory
            {
                Id = 1,
                Name = "Games",
                Description = "TestDescription",
                AddedByUserId = "222x",
            };
            await db.ForumCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var post = new Post
            {
                Id = 1,
                Title = "Some post title",
                Content = "Some content....",
                AddedByUserId = user.Id,
                CategoryId = 1,
            };
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();

            var model = new CreateCommentInputViewModel
            {
                PostId = 1,
                Content = "Content good very good",
            };

            await comentService.CreateCommentAsync(model, user.Id, post.Id);

            var resultBeforeDeletingComment = db.Posts.Where(x => x.Id == 1).FirstOrDefault().Comments.Count();

            await comentService.DeleteCommentAsync(post.Id);

            var resultAfterDeletingComment = db.Posts.Where(x => x.Id == 1).FirstOrDefault().Comments.Where(c => c.IsDeleted == false).Count();

            Assert.Equal(1, resultBeforeDeletingComment);
            Assert.Equal(0, resultAfterDeletingComment);
        }
    }
}
