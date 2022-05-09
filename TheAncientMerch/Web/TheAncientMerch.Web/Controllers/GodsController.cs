namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.GreekDeity;

    public class GodsController : Controller
    {
        public GodsController(IGreekDeityService greekDeityService)
        {
            this.GreekDeityService = greekDeityService;
        }

        public IGreekDeityService GreekDeityService { get; }

        public IActionResult All()
        {
            var view = this.GreekDeityService.GetAllGods();
            return this.View(view);
        }

    }
}
