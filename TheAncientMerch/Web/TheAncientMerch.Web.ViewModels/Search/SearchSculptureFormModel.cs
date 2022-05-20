namespace TheAncientMerch.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SearchSculptureFormModel
    {
        public string Keyword { get; set; }

        public IEnumerable<SculptureViewModel> Sculptures { get; set; }
    }
}
