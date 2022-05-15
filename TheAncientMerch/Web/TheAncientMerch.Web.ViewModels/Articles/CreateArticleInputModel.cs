namespace TheAncientMerch.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    using static TheAncientMerch.Common.DataConstants;

    public class CreateArticleInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MaxLength(ArticleTitleMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        [MinLength(ArticleTitleMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [Display(Name = "Article title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(ArticleContentMinLength, ErrorMessage = "The content must have at least {1} letters")]
        [MaxLength(ArticleContentMaxLength, ErrorMessage = "The content must have maximum {1} letters")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Choose article category")]
        public int CategoryId { get; set; }

        // Dropdown Menu
        public IEnumerable<ArticleCategoryViewModel> Categories { get; set; }
    }
}