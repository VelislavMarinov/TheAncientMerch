namespace TheAncientMerch.Services.Data.SculptureMaterial
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public interface ISculptureMaterialService
    {
        IEnumerable<SculptureMaterialViewModel> GetAllMaterials();
    }
}
