namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using TheAncientMerch.Services.Data.Accounts;
    using TheAncientMerch.Web.ViewModels.Account;

    [Authorize]
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

        [HttpGet]
        public IActionResult PaymentsHistory(string route = "Bought")
        {
            route = route.ToLower();

            IEnumerable<PaymentViewModel> paymentsModel;

            var userId = this.User.GetId();

            if (route == "bought")
            {
                paymentsModel = this.accountService.GetUserBoughtSculpturesPayments(userId);
                return this.View(paymentsModel);
            }
            else if (route == "sold")
            {
                paymentsModel = this.accountService.GetUserSoldSculpturesPayments(userId);
                return this.View(paymentsModel);
            }

            return this.Redirect($"/Accounts/MyAccount");
        }
    }
}
