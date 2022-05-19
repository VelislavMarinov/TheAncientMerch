namespace TheAncientMerch.Web.ViewModels.Sculptures
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class EditSculptureViewModel
    {
        public int Id { get; set; }

        [MinLength(SculptureNameMinLegth, ErrorMessage = "The name must have at least {1} letters")]
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
        [Range(5, 300)]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(5, 150)]
        public decimal Width { get; set; }

        [Range(0, 30)]
        public decimal Weigth { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(SculptureDescriptionMinLength, ErrorMessage = "The description must have at least {1} letters")]
        [MaxLength(SculptureDescriptionMaxLength, ErrorMessage = "The description must have maximum {1} letters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Made of material")]
        public int MaterialId { get; set; }

        public IEnumerable<SculptureMaterialViewModel> Materials { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public SculptureColor Color { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Type of sculpture")]
        public SculptureType SculptureType { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(OriginMinLegth, ErrorMessage = "The origin must have at least {1} letters")]
        [MaxLength(OriginMaxLegth, ErrorMessage = "The origin must have maximum {1} letters")]
        public string Origin { get; set; }
    }
}