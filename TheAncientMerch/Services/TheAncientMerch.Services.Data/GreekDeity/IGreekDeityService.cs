namespace TheAncientMerch.Services.Data.GreekDeity
{
    using System.Collections.Generic;

    using TheAncientMerch.Web.ViewModels.GreekDeitys;

    public interface IGreekDeityService
    {
        IEnumerable<DeityViewModel> GetAllGods();

        IEnumerable<DeityViewModel> GetAllTitans();

        DeityViewModel GetDeity(int id);

    }
}
