namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.GreekDeity;

    public class TitansController : Controller
    {
        public TitansController(IGreekDeityService greekDeityService)
        {
            this.GreekDeityService = greekDeityService;
        }

        public IGreekDeityService GreekDeityService { get; }

        public IActionResult All()
        {
            var view = this.GreekDeityService.GetAllTitans();
            return this.View(view);
        }

    }
}
