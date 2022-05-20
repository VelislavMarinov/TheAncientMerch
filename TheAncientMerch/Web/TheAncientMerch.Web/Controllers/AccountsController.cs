namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AccountsController : Controller
    {

        [HttpGet]
        public IActionResult MyAccount()
        {
            return this.View();
        }
    }
}
