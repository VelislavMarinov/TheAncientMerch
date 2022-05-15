namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TheAncientMerch.Services.Data.GreekDeity;

    [Authorize]
    public class DeitiesController : Controller
    {
        public DeitiesController(IGreekDeityService greekDeityService)
        {
            this.GreekDeityService = greekDeityService;
        }

        public IGreekDeityService GreekDeityService { get; }

        public IActionResult Gods()
        {
            var view = this.GreekDeityService.GetAllGods();
            return this.View(view);
        }

        public IActionResult Titans()
        {
            var view = this.GreekDeityService.GetAllTitans();
            return this.View(view);
        }

        public IActionResult Deity(int id)
        {
            var god = this.GreekDeityService.GetDeity(id);

            return this.View(god);
        }
    }
}
