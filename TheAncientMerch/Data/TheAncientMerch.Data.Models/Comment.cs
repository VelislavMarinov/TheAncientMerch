namespace TheAncientMerch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
