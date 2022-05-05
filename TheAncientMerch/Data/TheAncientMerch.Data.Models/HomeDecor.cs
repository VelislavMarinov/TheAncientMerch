namespace TheAncientMerch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class HomeDecor : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(HomeDecorNameMaxLegth)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Width { get; set; }

        public decimal? Weigth { get; set; }

        public decimal? Depth { get; set; }

        [Required]
        [MaxLength(HomeDecorDescriptionMaxLength)]
        public string Description { get; set; }

        public int MaterialId { get; set; }

        [Required]
        public HomeDecorMaterial Material { get; set; }

        [Required]
        public HomeDocerColor Color { get; set; }

        [Required]
        public HomeDecorType HomeDecorType { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        [MaxLength(OriginMaxLegth)]
        public string Origin { get; set; }
    }
}
