namespace TheAncientMerch.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class GreekDeity : BaseModel<int>
    {
        public GreekDeity()
        {
            this.Sculptures = new HashSet<Sculpture>();
        }

        [Required]
        [MaxLength(GreekDeityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(GreekDeityDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        public DeityType Type { get; set; }

        public ICollection<Sculpture> Sculptures { get; set; }
    }
}
