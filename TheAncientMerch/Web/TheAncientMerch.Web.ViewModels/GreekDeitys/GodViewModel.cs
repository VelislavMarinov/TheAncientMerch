namespace TheAncientMerch.Web.ViewModels.GreekDeitys
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GodViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }
    }
}
