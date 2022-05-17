using System.Threading.Tasks;
using TheAncientMerch.Web.ViewModels.Forum;

namespace TheAncientMerch.Services.Data.Forum
{
    public interface IForumService
    {
        Task CreateCategoryAsync(CreateForumInputViewModel mode, string userId);
    }
}
