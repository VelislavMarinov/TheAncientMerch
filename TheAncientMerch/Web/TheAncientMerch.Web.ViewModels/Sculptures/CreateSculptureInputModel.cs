namespace TheAncientMerch.Web.ViewModels.Sculptures
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class CreateSculptureInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(SculptureNameMinLegth, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(SculptureNameMaxLegth, ErrorMessage = "The name must have maximum {1} letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(5, 10000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Url]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(5, 200)]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(5, 100)]
        public decimal Width { get; set; }

        [Range(0,30)]
        public decimal Weigth { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(SculptureDescriptionMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(SculptureDescriptionMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Made of material")]
        public int MaterialId { get; set; }

        // Dropdown Menu
        public IEnumerable<SculptureMaterialViewModel> Materials { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public SculptureColor Color { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Type of sculpture")]
        public SculptureType SculptureType { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(OriginMinLegth, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(OriginMaxLegth, ErrorMessage = "The name must have maximum {1} letters")]
        public string Origin { get; set; }
    }
}
