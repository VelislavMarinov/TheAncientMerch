namespace TheAncientMerch.Web.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TheAncientMerch.Services.Data.Accounts;
    using TheAncientMerch.Services.Data.Sculpture;
    using TheAncientMerch.Web.ViewModels.Account;

    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ISculptureService sculptureService;

        public AccountsController(
            IAccountService accountService,
            ISculptureService sculptureService)
        {
            this.accountService = accountService;
            this.sculptureService = sculptureService;
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

        [HttpGet]
        public IActionResult MySculptures()
        {
            var userId = this.User.GetId();
            var sculpturesView = this.sculptureService.GetAllUserSculptures(userId);
            return this.View(sculpturesView);
        }
    }
}
