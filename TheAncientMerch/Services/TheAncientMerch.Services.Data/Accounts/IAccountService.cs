namespace TheAncientMerch.Services.Data.Accounts
{
    using System.Collections.Generic;
    using TheAncientMerch.Web.ViewModels.Account;

    public interface IAccountService
    {
       AccountViewModel GetAccountViewModel(string userId);

       IEnumerable<PaymentViewModel> GetUserBoughtSculpturesPayments(string userId);

       IEnumerable<PaymentViewModel> GetUserSoldSculpturesPayments(string userId);
    }
}
