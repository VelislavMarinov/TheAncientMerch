namespace TheAncientMerch.Web.ViewModels.GreekDeitys
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class AllSculpturesViewModel : PagingViewModel
    {
        public IEnumerable<SculptureViewModel> Sculptures { get; set; }
    }
}
