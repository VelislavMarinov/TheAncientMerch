namespace TheAncientMerch.Services.Data.Article
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.Articles;

    public interface IArticleService
    {
        IEnumerable<ArticlesCategoryViewModel> GetAllCategories();

        IEnumerable<ArticleViewModel> GetAllArticles(int pageNumber, int itemsPerPage);

        int ArticlesCount();
    }
}
