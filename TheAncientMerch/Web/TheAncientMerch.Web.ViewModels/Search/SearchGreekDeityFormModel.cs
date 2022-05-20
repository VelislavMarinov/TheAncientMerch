namespace TheAncientMerch.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.GreekDeitys;

    public class SearchGreekDeityFormModel
    {
        public string Name { get; set; }

        public DeityViewModel Deity { get; set; }
    }
}
