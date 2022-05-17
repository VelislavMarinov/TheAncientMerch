namespace TheAncientMerch.Services.Data.Forum
{
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Forum;

    public class ForumService : IForumService
    {
        public ForumService(IDeletableEntityRepository<ForumCategory> forumRepository)
        {
            this.ForumRepository = forumRepository;
        }

        public IDeletableEntityRepository<ForumCategory> ForumRepository { get; }

        public Task CreateCategoryAsync(CreateForumInputViewModel mode, string userId)
        {


            throw new System.NotImplementedException();
        }
    }
}
