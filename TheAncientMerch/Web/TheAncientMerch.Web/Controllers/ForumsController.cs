namespace TheAncientMerch.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Forum;
    using TheAncientMerch.Web.ViewModels.Forum;

    [Authorize]
    public class ForumsController : Controller
    {
        public ForumsController(IForumService forumService)
        {
            this.ForumService = forumService;
        }

        public IForumService ForumService { get; }

        [HttpGet]
        public IActionResult Categories()
        {
            var viewModel = new AllCategoriesViewModel()
            {
                Categories = this.ForumService.GetAllCategories(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Category(string id)
        {
            var viewModel = this.ForumService.GetCategoryByName(id);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateForumInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();

            await this.ForumService.CreateCategoryAsync(model, userId);

            this.TempData["Message"] = "Category created successfully.";

            return this.Redirect("/Forums/Categories");
        }
    }
}
