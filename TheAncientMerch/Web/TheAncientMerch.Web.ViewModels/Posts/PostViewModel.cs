namespace TheAncientMerch.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.Comments;

    public class PostViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AddedByUserId { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserUserName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
