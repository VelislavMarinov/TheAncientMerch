namespace TheAncientMerch.Services.Data.Accounts
{
    using TheAncientMerch.Web.ViewModels.Account;

    public interface IAccountService
    {
       AccountViewModel GetAccountViewModel(string userId);
    }
}
