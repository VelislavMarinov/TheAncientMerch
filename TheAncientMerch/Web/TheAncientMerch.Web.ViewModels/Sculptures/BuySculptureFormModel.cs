namespace TheAncientMerch.Web.ViewModels.Sculptures
{
    using System.ComponentModel.DataAnnotations;

    using static TheAncientMerch.Common.DataConstants;

    public class BuySculptureFormModel
    {
        public BuySculptureViewModel SculptureModel { get; set; }

        public byte DeliveryPrice { get; set; } = 5;

        public byte VAT { get; set; } = 1;

        public int SculptureId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [MinLength(FirstNameMinLength, ErrorMessage = "The name must have at least {1} letters")]
        [MaxLength(FirstNameMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(LastNameMinLength, ErrorMessage = "The name must have at least {1} letters")]
        [MaxLength(LastNameMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(AddressMinLength, ErrorMessage = "The adress must have at least {1} letters")]
        [MaxLength(AddressMaxLength, ErrorMessage = "The adress must have maximum {1} letters")]
        public string Address { get; set; }

        [Display(Name = "Card Name")]
        [Required]
        [MinLength(CardNameMinLength, ErrorMessage = "The card name must have at least {1} letters")]
        [MaxLength(CardNameMaxLength, ErrorMessage = "The card name must have maximum {1} letters")]
        public string CardName { get; set; }

        [Display(Name = "Card Number")]
        [Required]
        [MinLength(CardNumberMinLength, ErrorMessage = "The card number must have at least {1} numbers")]
        [MaxLength(CardNumberMaxLength, ErrorMessage = "The card number must have maximum {1} numbers")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration")]
        [Required]
        [MinLength(ExpirationMinLength, ErrorMessage = "The expiration must have at least {1} numbers")]
        [MaxLength(ExpirationMaxLength, ErrorMessage = "The expiration must have maximum {1} numbers")]
        public string Expiration { get; set; }

    }
}
