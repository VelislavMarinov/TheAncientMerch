namespace TheAncientMerch.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;

    using Microsoft.AspNetCore.Mvc;

    using TheAncientMerch.Web.ViewModels.Forum;

    [Authorize]
    public class ForumsController : Controller
    {
        [HttpGet]
        public IActionResult Categories()
        {
            return this.View();
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
            return this.Redirect("/Forums/Categories");
        }
    }
}
