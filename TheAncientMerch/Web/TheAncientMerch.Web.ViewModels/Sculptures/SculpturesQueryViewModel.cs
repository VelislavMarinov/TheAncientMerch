namespace TheAncientMerch.Web.ViewModels.GreekDeitys
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculpturesQueryViewModel : PagingViewModel
    {
        public IEnumerable<SculptureViewModel> Sculptures { get; set; }

        [Display(Name = "Sculpture Color")]
        public int? Color { get; set; }

        [Display(Name = "Sculpture material")]
        public string Material { get; set; }

        [Display(Name = "Sculpture type")]
        public int? SculptureType { get; set; }

        public IEnumerable<string> Materials { get; set; }

    }
}
