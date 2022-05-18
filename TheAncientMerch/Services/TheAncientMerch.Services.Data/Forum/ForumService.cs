namespace TheAncientMerch.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Forum;

    public class ForumService : IForumService
    {
        public ForumService(
            IDeletableEntityRepository<ForumCategory> forumRepository,
            IDeletableEntityRepository<Post> postRepository)
        {
            this.ForumRepository = forumRepository;
            this.PostRepository = postRepository;
        }

        public IDeletableEntityRepository<ForumCategory> ForumRepository { get; }

        public IDeletableEntityRepository<Post> PostRepository { get; }

        public async Task CreateCategoryAsync(CreateForumInputViewModel mode, string userId)
        {
            var category = new ForumCategory()
            {
                Name = mode.Name,
                Description = mode.Description,
                AddedByUserId = userId,
            };

            await this.ForumRepository.AddAsync(category);
            await this.ForumRepository.SaveChangesAsync();
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var categories = this.ForumRepository
                .All()
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    PostsCount = this.PostRepository.All().Where(p => p.CategoryId == x.Id).Count(),

                })
                .ToList();

            return categories;
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            var viewModel = this.ForumRepository
               .All()
               .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
               .Select(x => new CategoryViewModel {
                   Description = x.Description,
                   Name = x.Name,
                   Posts = this.PostRepository
                     .All()
                     .Where(p => p.CategoryId == x.Id)
                     .Select(p => new CategoryPostsViewModel
                     {
                         Id = p.Id,
                         Title = p.Title,
                         Content = p.Content,
                         CreatedOn = p.CreatedOn,
                         AddedByUserUserName = p.AddedByUser.UserName,
                         CommentsCount = p.Comments.Count(),
                     })
                     .ToList(),
                   PostsCount = this.PostRepository.All().Where(p => p.CategoryId == x.Id).Count(),
               })
               .FirstOrDefault();

            return viewModel;
        }
    }
}
