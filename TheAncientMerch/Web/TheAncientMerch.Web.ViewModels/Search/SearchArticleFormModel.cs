namespace TheAncientMerch.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.Articles;

    public class SearchArticleFormModel
    {
        public string Keyword { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}