﻿namespace TheAncientMerch.Web.ViewModels.Sculptures
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
        public int MaterialId { get; set; }

        public IEnumerable<SculptureMaterialViewModel> Materials { get; set; }

        public bool? IsMale { get; set; }

        public bool IsGardenStatue { get; set; }

        public SculptureColor Color { get; set; }

        public SculptureType SculptureType { get; set; }

        [Required]
        public string Origin { get; set; }
    }
}