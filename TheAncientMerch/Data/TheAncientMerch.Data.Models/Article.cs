namespace TheAncientMerch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheAncientMerch.Data.Common.Models;

    using static TheAncientMerch.Common.DataConstants;

    public class Article : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ArticleTitleMaxLength)]

        public string Title { get; set; }

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        public string Content { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual ArticleCategory Category { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
