namespace TheAncientMerch.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Article;
    using TheAncientMerch.Web.ViewModels.Articles;

    public class ArticlesController : Controller
    {
        public ArticlesController(
            IArticleService articleService)
        {
            this.ArticleService = articleService;
        }

        public IArticleService ArticleService { get; }

        [HttpGet]
        public IActionResult Categories(string id = "Categories")
        {
            id = id.ToLower();
            var categories = this.ArticleService.GetAllCategories();

            // for a spacific category.
            foreach (var category in categories)
            {
               var categoryNameTrimed = string.Concat(category.Name.Where(c => !char.IsWhiteSpace(c))).ToLower();
               if (id == categoryNameTrimed)
               {
                    var articlesByCategory = this.ArticleService.GetArticlesById(category.Id);
                    var viewModel = new AllArticlesViewModel
                    {
                        Articles = this.ArticleService.GetArticlesById(category.Id),
                        ItemsCount = this.ArticleService.ArticlesCount(),
                    };
                    return this.View($"{id}", viewModel);
               }
            }

            // for all categories.
            return this.View(categories);
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            var itemsPerPage = 3;
            var view = new AllArticlesViewModel
            {
                PageNumber = id,
                Articles = this.ArticleService.GetAllArticles(id, itemsPerPage),
                ItemsPerPage = itemsPerPage,
                ItemsCount = this.ArticleService.ArticlesCount(),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel
            {
                Categories = this.ArticleService.GetAllCategories(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.ArticleService.GetAllCategories();

                return this.View(model);
            }

            var userId = this.User.GetId();

            await this.ArticleService.CreateArticleAsync(model, userId);

            ArticlesController articlesController = this;
            articlesController.TempData["Message"] = "Article created successfully.";

            return this.RedirectToAction("All", "Articles");
        }

    }
}
