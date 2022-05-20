namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Accounts;

    public class AccountsController : Controller
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult MyAccount()
        {
            var userId = this.User.GetId();

            var viewModel = this.accountService.GetAccountViewModel(userId);
            return this.View(viewModel);
        }
    }
}
