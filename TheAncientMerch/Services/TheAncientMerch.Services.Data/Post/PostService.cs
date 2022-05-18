namespace TheAncientMerch.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Comments;
    using TheAncientMerch.Web.ViewModels.Forum;
    using TheAncientMerch.Web.ViewModels.Posts;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<ForumCategory> forumCategoryRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public PostService(
            IDeletableEntityRepository<ForumCategory> forumCategoryRepository,
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Comment> commentRepository)
        {
            this.forumCategoryRepository = forumCategoryRepository;
            this.postRepository = postRepository;
            this.usersRepository = usersRepository;
            this.commentRepository = commentRepository;
        }

        public async Task<int> CreatePostAsync(CreatePostsInputViewModel model, string userId)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                AddedByUserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public IEnumerable<CategoryViewModel> GetForumCategories()
        {
            var viewModel = this.forumCategoryRepository
               .AllAsNoTracking()
               .Select(x => new CategoryViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .ToList();

            return viewModel;
        }

        public PostViewModel GetPostById(int id)
        {
            var post = this.postRepository
               .All()
               .Where(x => x.Id == id)
               .Select(x => new PostViewModel
               {
                   Id = x.Id,
                   CategoryName = x.Category.Name,
                   Title = x.Title,
                   Content = x.Content,
                   AddedByUserId = x.AddedByUserId,
                   AddedByUserUserName = x.AddedByUser.UserName,
                   CreatedOn = x.CreatedOn,
               })
               .FirstOrDefault();

            var comments = this.commentRepository
                .All()
                .Where(x => x.PostId == post.Id)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    AddedByUserUserName = x.AddedByUser.UserName,
                    AddedByUserId = x.AddedByUserId,
                })
                .ToList();

            post.Comments = comments;

            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = this.postRepository
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            this.postRepository.Delete(post);
            await this.postRepository.SaveChangesAsync();
        }

    }
}
