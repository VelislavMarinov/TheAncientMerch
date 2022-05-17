namespace TheAncientMerch.Web.ViewModels.Forum
{
    using System.ComponentModel.DataAnnotations;

    using static TheAncientMerch.Common.DataConstants;

    public class CreateForumInputViewModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(ForumCategoryNameMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(ForumCategoryNameMaxLength, ErrorMessage = "The name must have maximum {1} letters")]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(ForumCategoryDescriptionMinLength, ErrorMessage = "The title must have at least {1} letters")]
        [MaxLength(ForumCategoryDescriptionMaxLength,ErrorMessage = "The name must have maximum {1} letters")]
        public string Description { get; set; }
    }
}
