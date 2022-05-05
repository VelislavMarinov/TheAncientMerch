namespace TheAncientMerch.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class SculptureMaterial : BaseModel<int>
    {
        public SculptureMaterial()
        {
            this.Sculptures = new HashSet<Sculpture>();
        }

        [Required]
        [MaxLength(SculptureMaterialNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Sculpture> Sculptures { get; set; }
    }
}
