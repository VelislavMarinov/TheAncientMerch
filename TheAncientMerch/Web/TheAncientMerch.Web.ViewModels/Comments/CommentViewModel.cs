namespace TheAncientMerch.Web.ViewModels.Comments
{
    using System;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
