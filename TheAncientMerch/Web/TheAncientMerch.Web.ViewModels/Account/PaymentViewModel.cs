namespace TheAncientMerch.Web.ViewModels.Account
{
    using System;

    public class PaymentViewModel
    {
        public string BuyerName { get; set; }

        public string SellerName { get; set; }

        public DateTime SoldDate { get; set; }

        public decimal SculpturePrice { get; set; }

        public string SculptureName { get; set; }

        public DateTime SculptureCreatedOn { get; set; }
    }
}
