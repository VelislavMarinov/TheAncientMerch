namespace TheAncientMerch.Services.Data.Post
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Forum;
    using TheAncientMerch.Web.ViewModels.Posts;

    public interface IPostService
    {
        IEnumerable<CategoryViewModel> GetForumCategories();

        Task DeletePostAsync(int postId);

        Task<int> CreatePostAsync(CreatePostsInputViewModel model, string userId);

        PostViewModel GetPostById(int id);
    }
}
