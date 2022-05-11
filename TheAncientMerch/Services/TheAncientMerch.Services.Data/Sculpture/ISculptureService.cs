namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISculptureService
    {
        Task Create(CreateSculptureInputModel createSculptureInputModel);
    }
}
