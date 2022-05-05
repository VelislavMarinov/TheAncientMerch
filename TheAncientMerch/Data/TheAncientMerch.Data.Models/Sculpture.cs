﻿namespace TheAncientMerch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class Sculpture : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(SculptureMaterialNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Weigth { get; set; }

        [Required]
        [MaxLength(SculptureDescriptionMaxLength)]
        public string Description { get; set; }

        public int MaterialId { get; set; }

        [Required]
        public SculptureMaterial Material { get; set; }

        public bool? IsMale { get; set; }

        public int GreekDeityId { get; set; }

        public GreekDeity GreekDeity { get; set; }

        public bool? IsGardenStatue { get; set; }

        [Required]
        public SculptureColor Color { get; set; }

        [Required]
        public SculptureType SculptureType { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        [MaxLength(OriginMaxLegth)]
        public string Origin { get; set; }
    }
}
