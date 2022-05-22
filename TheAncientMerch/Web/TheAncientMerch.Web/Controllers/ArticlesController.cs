namespace TheAncientMerch.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Article;
    using TheAncientMerch.Web.ViewModels.Articles;

    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(
            IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public IActionResult Categories(string id = "Categories")
        {
            id = id.ToLower();
            var categories = this.articleService.GetAllCategories();

            // for a spacific category.
            foreach (var category in categories)
            {
               var categoryNameTrimed = string.Concat(category.Name.Where(c => !char.IsWhiteSpace(c))).ToLower();
               if (id == categoryNameTrimed)
               {
                    var viewModel = new AllArticlesViewModel
                    {
                        Articles = this.articleService.GetArticlesByCategoryId(category.Id),
                        ItemsCount = this.articleService.ArticlesCount(),
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
                Articles = this.articleService.GetAllArticles(id, itemsPerPage),
                ItemsPerPage = itemsPerPage,
                ItemsCount = this.articleService.ArticlesCount(),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel
            {
                Categories = this.articleService.GetAllCategories(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.articleService.GetAllCategories();

                return this.View(model);
            }

            var userId = this.User.GetId();

            await this.articleService.CreateArticleAsync(model, userId);

            ArticlesController articlesController = this;

            articlesController.TempData["Message"] = "Article created successfully.";

            return this.RedirectToAction("All", "Articles");
        }

        [HttpGet]
        public IActionResult Article(int id)
        {
            var article = this.articleService.GetArticleById(id);
            return this.View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.articleService.DeleteArticleAsync(id);
            this.TempData["Message"] = "Article deleted successfully.";
            return this.RedirectToAction("All", "Articles");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new EditArticleInputModel();
            var currentArticle = this.articleService.GetArticleById(id);

            viewModel.Title = currentArticle.Title;
            viewModel.Content = currentArticle.Content;
            viewModel.Categories = this.articleService.GetAllCategories();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, EditArticleInputModel model)
        {
            var userId = this.User.GetId();

            if (!this.ModelState.IsValid)
            {
                model.Categories = this.articleService.GetAllCategories();

                return this.View(model);
            }

            await this.articleService.EditArticleAsync(model, id, userId);

            ArticlesController articlesController = this;

            articlesController.TempData["Message"] = "Article updated successfully.";

            return this.Redirect($"/Articles/Article/{id}");
        }
    }
}
