namespace TheAncientMerch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class Payment : BaseDeletableModel<int>
    {
        [Required]
        public int SculptureId { get; set; }

        public virtual Sculpture Sculpture { get; set; }

        public string BuyerId { get; set; }

        public ApplicationUser Buyer { get; set; }

        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(LastNameMinLength)]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMinLength)]
        public string Address { get; set; }

        [Required]
        [MinLength(CardNameMinLength)]
        [MaxLength(CardNameMaxLength)]
        public string CardName { get; set; }

        [Required]
        [MinLength(CardNumberMinLength)]
        [MaxLength(CardNumberMaxLength)]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(ExpirationMinLength)]
        [MaxLength(ExpirationMaxLength)]
        public string Expiration { get; set; }
    }
}
