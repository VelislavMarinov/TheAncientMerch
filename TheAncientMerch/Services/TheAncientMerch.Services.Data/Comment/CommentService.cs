namespace TheAncientMerch.Services.Data.Comment
{
    using System.Threading.Tasks;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Web.ViewModels.Comments;
    using TheAncientMerch.Data.Models;
    using System.Linq;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(CreateCommentInputViewModel model, string userId, int postId)
        {
            var comment = new Comment
            {
                Content = model.Content,
                PostId = postId,
                AddedByUserId = userId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = this.commentRepository
               .All()
               .Where(x => x.Id == commentId)
               .FirstOrDefault();

            this.commentRepository.Delete(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
