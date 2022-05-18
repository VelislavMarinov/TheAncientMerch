namespace TheAncientMerch.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Post;
    using TheAncientMerch.Web.ViewModels.Posts;

    [Authorize]
    public class PostsController : Controller
    {
        public IPostService PostService { get; }

        public PostsController(IPostService postService)
        {
            this.PostService = postService;
        }

        [HttpGet]
        public IActionResult Post(int id)
        {
            var viewModel = this.PostService.GetPostById(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreatePostsInputViewModel
            {
                Categories = this.PostService.GetForumCategories(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostsInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.PostService.GetForumCategories();
                return this.View(model);
            }

            var userId = this.User.GetId();
            var postId = await this.PostService.CreatePostAsync(model, userId);

            this.TempData["Message"] = "Post created successfully.";

            return this.RedirectToAction("Post", new { id = postId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.PostService.DeletePostAsync(id);
            this.TempData["Message"] = "Post deleted successfully.";
            return this.RedirectToAction("Categories", "Forums");
        }
    }
}
