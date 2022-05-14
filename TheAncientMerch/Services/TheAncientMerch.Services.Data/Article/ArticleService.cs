namespace TheAncientMerch.Services.Data.Article
{
    using System.Collections.Generic;

    using System.Linq;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.Articles;

    public class ArticleService : IArticleService
    {
        public ArticleService(IDeletableEntityRepository<ArticleCategory> articleCategoryRepository,
            IDeletableEntityRepository<Article> articleRepository)
        {
            this.ArticleCategoryRepository = articleCategoryRepository;
            this.ArticleRepository = articleRepository;
        }

        public IDeletableEntityRepository<ArticleCategory> ArticleCategoryRepository { get; }

        public IDeletableEntityRepository<Article> ArticleRepository { get; }

        public IEnumerable<ArticleViewModel> GetAllArticles(int pageNumber, int itemsPerPage)
        {
            var viewModel = this.ArticleRepository
                .All()
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
             .Select(x => new ArticleViewModel
             {
                 Id = x.Id,
                 Title = x.Title,
                 Content = x.Content,
                 CategoryId = x.CategoryId,
                 CategoryName = x.Category.Name,
                 ImagePath = x.ImageUrl,
                 UserId = x.AddedByUserId,
                 CreatedOn = x.CreatedOn.ToString("f"),
                 Username = x.AddedByUser.UserName,
             })
             .ToList();

            return viewModel;
        }

        public IEnumerable<ArticlesCategoryViewModel> GetAllCategories()
        {
            var categories = this.ArticleCategoryRepository
                .All()
                .Select(x => new ArticlesCategoryViewModel
                {
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                });

            return categories;
        }

        public int ArticlesCount()
        {
            var articlesCount = this.ArticleRepository
                .All()
                .Count();

            return articlesCount;
        }
    }
}
