namespace TheAncientMerch.Services.Data.SculptureMaterial
{
    using System.Collections.Generic;

    using System.Linq;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculptureMaterialService : ISculptureMaterialService
    {
        private readonly IRepository<SculptureMaterial> sculptureMaterialRepository;

        public SculptureMaterialService(IRepository<SculptureMaterial> sculptureMaterialRepository)
        {
            this.sculptureMaterialRepository = sculptureMaterialRepository;
        }

        public IEnumerable<SculptureMaterialViewModel> GetAllMaterials()
        {
            var material = this.sculptureMaterialRepository.All()
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
