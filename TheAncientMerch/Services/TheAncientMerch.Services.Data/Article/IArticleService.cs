namespace TheAncientMerch.Services.Data.Article
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheAncientMerch.Web.ViewModels.Articles;

    public interface IArticleService
    {
        IEnumerable<ArticleCategoryViewModel> GetAllCategories();

        IEnumerable<ArticleViewModel> GetArticlesById(int Id);

        IEnumerable<ArticleViewModel> GetAllArticles(int pageNumber, int itemsPerPage);

        Task CreateArticleAsync(CreateArticleInputModel model, string userId);

        int ArticlesCount();

    }
}
