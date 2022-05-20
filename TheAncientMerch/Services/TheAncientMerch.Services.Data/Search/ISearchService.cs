namespace TheAncientMerch.Services.Data.Search
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.Articles;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISearchService
    {

        IEnumerable<ArticleViewModel> SearchArticleByKeyword(string keyword);

        IEnumerable<SculptureViewModel> SearcSculptureByKeyword(string keyword);

        DeityViewModel SearchGreekDeityByUsername(string username);
    }
}
