namespace TheAncientMerch.Services.Data.Comment
{
    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Comments;

    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentInputViewModel model, string userId, int postId);

        Task DeleteCommentAsync(int postId);
    }
}
