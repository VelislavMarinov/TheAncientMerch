namespace TheAncientMerch.Services.Data.SculptureMaterial
{
    using System.Collections.Generic;

    using System.Linq;
    using System.Threading.Tasks;
    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculptureMaterialService : ISculptureMaterialService
    {
        public SculptureMaterialService(
            IRepository<SculptureMaterial> sculptureMaterialRepository)
        {
            this.SculptureMaterialRepository = sculptureMaterialRepository;
        }

        public IRepository<SculptureMaterial> SculptureMaterialRepository { get; }

        public IEnumerable<SculptureMaterialViewModel> GetAllMaterials()
        {
            var material = this.SculptureMaterialRepository.All()
                .Select(x => new SculptureMaterialViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .ToList();

            return material;
        }
    }
}
