namespace TheAncientMerch.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Comment;
    using TheAncientMerch.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IActionResult Reply()
        {
            var viewModel = new CreateCommentInputViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int id, CreateCommentInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();
            await this.commentService.CreateCommentAsync(model, userId, id);

            return this.RedirectToAction("Post", "Posts", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId, int postId)
        {
            await this.commentService.DeleteCommentAsync(commentId);
            return this.RedirectToAction("Post", "Posts", new { id = postId });
        }
    }
}
