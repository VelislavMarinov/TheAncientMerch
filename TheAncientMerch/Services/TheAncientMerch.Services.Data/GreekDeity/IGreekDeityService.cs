namespace TheAncientMerch.Services.Data.GreekDeity
{
    using System.Collections.Generic;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;

    public interface IGreekDeityService 
    {
        IEnumerable<GodViewModel> GetAllGods();

        IEnumerable<TitanViewModel> GetAllTitans();
    }
}
