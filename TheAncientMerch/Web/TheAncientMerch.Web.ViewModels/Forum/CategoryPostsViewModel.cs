namespace TheAncientMerch.Web.ViewModels.Forum
{
    using System;

    public class CategoryPostsViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AddedByUserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
