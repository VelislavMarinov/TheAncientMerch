namespace TheAncientMerch.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class HomeDecorMaterial : BaseModel<int>
    {
        public HomeDecorMaterial()
        {
            this.HomeDecors = new HashSet<HomeDecor>();
        }

        [Required]
        [MaxLength(HomeDecorMaterialNameMaxLength)]
        public string Name { get; set; }

        public ICollection<HomeDecor> HomeDecors { get; set; }
    }
}
