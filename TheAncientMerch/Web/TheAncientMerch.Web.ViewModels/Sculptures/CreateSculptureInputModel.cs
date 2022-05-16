namespace TheAncientMerch.Web.ViewModels.Sculptures
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class CreateSculptureInputModel
    {
        [MinLength(SculptureNameMinLegth)]
        [MaxLength(SculptureNameMaxLegth)]
        public string Name { get; set; }

        [Required]
        [Range(5, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Range(5, 200)]
        public decimal Height { get; set; }

        [Required]
        [Range(5, 100)]
        public decimal Width { get; set; }

        [Range(0,30)]
        public decimal Weigth { get; set; }

        [Required]
        [MinLength(SculptureDescriptionMinLength)]
        [MaxLength(SculptureDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Made of material")]
        public int MaterialId { get; set; }

        public IEnumerable<SculptureMaterialViewModel> Materials { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public bool? IsMale { get; set; }

        public SculptureColor Color { get; set; }

        [Required]
        [Display(Name = "Type of sculpture")]
        public SculptureType SculptureType { get; set; }

        [Required]
        public string Origin { get; set; }
    }
}
