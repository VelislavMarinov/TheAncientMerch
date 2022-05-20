namespace TheAncientMerch.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using TheAncientMerch.Services.Data.Search;
    using TheAncientMerch.Web.ViewModels.Articles;
    using TheAncientMerch.Web.ViewModels.Search;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult SearchArticle()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchArticle(SearchArticleFormModel model)
        {
            var articles = this.searchService.SearchArticleByKeyword(model.Keyword);
            if (articles.Any())
            {
                model.Articles = articles;
                model.Keyword = string.Empty;
                return this.View("FoundArticle", model);
            }
            else
            {
                this.TempData["Message"] = "There was no article title found with the given keyword.";
                return this.View();
            }
        }
    }
}
