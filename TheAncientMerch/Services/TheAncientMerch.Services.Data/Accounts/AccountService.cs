namespace TheAncientMerch.Services.Data.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Account;

    public class AccountService : IAccountService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Payment> paymentRepository;

        public AccountService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Payment> paymentRepository)
        {
            this.userRepository = userRepository;
            this.paymentRepository = paymentRepository;
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

        public IEnumerable<PaymentViewModel> GetUserBoughtSculpturesPayments(string userId)
        {
            var paymentView = this.paymentRepository
                .All()
                .Where(x => x.BuyerId == userId)
                .Select(x => new PaymentViewModel
                {
                    BuyerName = x.Buyer.UserName,
                    SellerName = x.Sculpture.AddedByUser.UserName,
                    SculptureCreatedOn = x.Sculpture.CreatedOn,
                    SculpturePrice = x.Sculpture.Price,
                    SculptureName = x.Sculpture.Name,
                    SoldDate = x.CreatedOn,
                })
                .ToList();

            return paymentView;
        }

        public IEnumerable<PaymentViewModel> GetUserSoldSculpturesPayments(string userId)
        {
            var paymentView = this.paymentRepository
                .All()
                .Where(x => x.Sculpture.AddedByUserId == userId)
                .Select(x => new PaymentViewModel
                {
                    BuyerName = x.Buyer.UserName,
                    SellerName = x.Sculpture.AddedByUser.UserName,
                    SculptureCreatedOn = x.Sculpture.CreatedOn,
                    SculpturePrice = x.Sculpture.Price,
                    SculptureName = x.Sculpture.Name,
                    SoldDate = x.CreatedOn,
                })
                .ToList();

            return paymentView;
        }
    }
}
