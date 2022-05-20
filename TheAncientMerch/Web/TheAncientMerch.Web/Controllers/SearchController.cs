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

        [HttpGet]
        public IActionResult SearchSculpture()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchSculpture(SearchSculptureFormModel model)
        {
            var sculptures = this.searchService.SearcSculptureByKeyword(model.Keyword);
            if (sculptures.Any())
            {
                model.Sculptures = sculptures;
                model.Keyword = string.Empty;
                return this.View("FoundSculpture", model);
            }
            else
            {
                this.TempData["Message"] = "There was no sculpture name found with the given keyword.";
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult SearchDeity()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchDeity(SearchGreekDeityFormModel model)
        {
            var deity = this.searchService.SearchGreekDeityByUsername(model.Name);
            if (deity != null)
            {
                model.Deity = deity;
                model.Name = string.Empty;
                return this.View("FoundDeity", model);
            }
            else
            {
                this.TempData["Message"] = "There was no deity name found with the given keyword.";
                return this.View();
            }
        }
    }
}
