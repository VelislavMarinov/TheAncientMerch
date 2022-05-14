namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Article;
    using TheAncientMerch.Web.ViewModels.Articles;

    public class ArticlesController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public ArticlesController(
            IArticleService articleService,
            IWebHostEnvironment environment)
        {
            this.Environment = environment;
            this.ArticleService = articleService;
        }

        public IArticleService ArticleService { get; }

        [HttpGet]
        public IActionResult Categories(string id = "Categories")
        {
            var view = this.ArticleService.GetAllCategories();
            return this.View($"{id}", view);
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            var itemsPerPage = 4;
            var view = new AllArticlesViewModel
            {
                PageNumber = id,
                Articles = this.ArticleService.GetAllArticles(id, itemsPerPage),
                ItemsPerPage = itemsPerPage,
                ItemsCount = this.ArticleService.ArticlesCount(),
            };

            return this.View(view);
        }
    }
}
