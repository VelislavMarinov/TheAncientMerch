namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Collections.Generic;

    using System.Threading.Tasks;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISculptureService
    {
        Task Create(CreateSculptureInputModel createSculptureInputModel, string userId);

        Task DeleteSculptureAsync(int id);

        Task<SculpturesQueryViewModel> GetAllSculptures(int id, int itemsPerPage, string material, int? sculptureType, int? color);

        Task BuySculpture(BuySculptureFormModel model, string userId);

        bool ChekIfSculptureIdIsValid(int id);

        BuySculptureViewModel GetSculptureForBuyViewModel(int id);

        IEnumerable<SculptureViewModel> GetAllUserSculptures();

        int GetCount();

        void DeleteSculpture(string userId, int sculptureId);

        SculptureViewModel GetSculptureById(int id);

        Task EditSculptureAsync(EditSculptureViewModel model, int sculptureId);
    }
}
