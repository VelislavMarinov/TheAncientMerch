namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Collections.Generic;

    using System.Threading.Tasks;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISculptureService
    {
        Task Create(CreateSculptureInputModel createSculptureInputModel);

        Task<SculpturesQueryViewModel> GetAllSculptures(int id, int itemsPerPage, string material, int? sculptureType, int? color);

        IEnumerable<SculptureViewModel> GetAllUserSculptures();

        int GetCount();

        void DeleteSculpture(string userId, int sculptureId);

        SculptureViewModel GetSculptureById(int id);
    }
}
