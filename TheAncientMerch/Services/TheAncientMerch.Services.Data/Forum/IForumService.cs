namespace TheAncientMerch.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Forum;

    public interface IForumService
    {
        Task CreateCategoryAsync(CreateForumInputViewModel mode, string userId);

        IEnumerable<CategoryViewModel> GetAllCategories();

        CategoryViewModel GetCategoryByName(string name);
    }
}
