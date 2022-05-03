namespace TheAncientMerch.Data.Models
{
    using TheAncientMerch.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
