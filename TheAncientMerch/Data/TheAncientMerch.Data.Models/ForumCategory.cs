namespace TheAncientMerch.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class ForumCategory : BaseDeletableModel<int>
    {
        public ForumCategory()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(ForumCategoryNameMinLength)]
        [MaxLength(ForumCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ForumCategoryDescriptionMinLength)]
        [MaxLength(ForumCategoryDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
