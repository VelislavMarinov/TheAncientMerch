namespace TheAncientMerch.Services.Data.Accounts
{
    using System;
    using System.Linq;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Account;

    public class AccountService : IAccountService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public AccountService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public AccountViewModel GetAccountViewModel(string userId)
        {
            var userView = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => new AccountViewModel
                {
                    Username = x.UserName,
                    Email = x.Email,
                    CreatedOn = x.CreatedOn,
                })
                .FirstOrDefault();

            return userView;
        }
    }
}
