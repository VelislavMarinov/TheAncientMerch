namespace TheAncientMerch.Web.ViewModels.Forum
{
    using System;
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PostsCount { get; set; }

        public IEnumerable<CategoryPostsViewModel> Posts { get; set; }

    }
}
