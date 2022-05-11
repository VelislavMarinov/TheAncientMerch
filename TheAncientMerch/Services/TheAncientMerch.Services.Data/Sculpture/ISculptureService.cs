namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Collections.Generic;

    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISculptureService
    {
        Task Create(CreateSculptureInputModel createSculptureInputModel);

        IEnumerable<SculptureViewModel> GetAllSculptures();

        IEnumerable<SculptureViewModel> GetSculpturesByColor();

        IEnumerable<SculptureViewModel> GetSculpturesByType();

        IEnumerable<SculptureViewModel> GetSculpturesByMaterial();

        IEnumerable<SculptureViewModel> GetSculpturesBySize();

        IEnumerable<SculptureViewModel> GetAllUserSculptures();

        void DeleteSculpture(string userId);

        SculptureViewModel GetSculptureById(int id);
    }
}
