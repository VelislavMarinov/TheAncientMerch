namespace TheAncientMerch.Services.Data.Article
{
    using System.Collections.Generic;

    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.Articles;

    public class ArticleService : IArticleService
    {

        private readonly IDeletableEntityRepository<ArticleCategory> articleCategoryRepository;

        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticleService(
            IDeletableEntityRepository<ArticleCategory> articleCategoryRepository,
            IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.articleRepository = articleRepository;
        }

       

        public IEnumerable<ArticleViewModel> GetAllArticles(int pageNumber, int itemsPerPage)
        {
            var viewModel = this.articleRepository
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
                 ImageUrl = x.ImageUrl,
                 UserId = x.AddedByUserId,
                 CreatedOn = x.CreatedOn.ToString("f"),
                 Username = x.AddedByUser.UserName,
             })
             .ToList();

            return viewModel;
        }

        public IEnumerable<ArticleCategoryViewModel> GetAllCategories()
        {
            var categories = this.articleCategoryRepository
                .All()
                .Select(x => new ArticleCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                });

            return categories;
        }

        public int ArticlesCount()
        {
            var articlesCount = this.articleRepository
                .All()
                .Count();

            return articlesCount;
        }

        public async Task CreateArticleAsync(CreateArticleInputModel model, string userId)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                AddedByUserId = userId,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public IEnumerable<ArticleViewModel> GetArticlesByCategoryId(int Id)
        {
            var articlesByCategory = this.articleRepository
                .All()
                .Where(x => x.CategoryId == Id)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    UserId = x.AddedByUserId,
                    CreatedOn = x.CreatedOn.ToString("f"),
                    Username = x.AddedByUser.UserName,
                })
                .ToList();

            return articlesByCategory;
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = this.articleRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.articleRepository.Delete(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public ArticleViewModel GetArticleById(int Id)
        {
            var article = this.articleRepository
                .All()
                .Where(x => x.Id == Id)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    UserId = x.AddedByUserId,
                    CreatedOn = x.CreatedOn.ToString("f"),
                    Username = x.AddedByUser.UserName,
                })
                .FirstOrDefault();
            return article;
        }

        public async Task EditArticleAsync(EditArticleInputModel model, int articleId, string userId)
        {
            var article = this.articleRepository
                .All()
                .Where(x => x.Id == articleId)
                .FirstOrDefault();

            article.Title = model.Title;
            article.Content = model.Content;
            article.CategoryId = model.CategoryId;
            article.ImageUrl = model.ImageUrl;

            this.articleRepository.Update(article);
            await this.articleRepository.SaveChangesAsync();
        }
    }
}
