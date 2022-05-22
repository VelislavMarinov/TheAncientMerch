namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TheAncientMerch.Services.Data.GreekDeity;

    [Authorize]
    public class DeitiesController : Controller
    {
        private readonly IGreekDeityService greekDeityService;

        public DeitiesController(IGreekDeityService greekDeityService)
        {
            this.greekDeityService = greekDeityService;
        }

        public IActionResult Gods()
        {
            var view = this.greekDeityService.GetAllGods();
            return this.View(view);
        }

        public IActionResult Titans()
        {
            var view = this.greekDeityService.GetAllTitans();
            return this.View(view);
        }

        public IActionResult Deity(int id)
        {
            var god = this.greekDeityService.GetDeity(id);

            return this.View(god);
        }
    }
}
