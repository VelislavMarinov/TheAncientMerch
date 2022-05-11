namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculptureService : ISculptureService
    {
        public SculptureService(IDeletableEntityRepository<Sculpture> sculptureRepository)
        {
            this.SculptureRepository = sculptureRepository;
        }

        public IDeletableEntityRepository<Sculpture> SculptureRepository { get; }

        public async Task Create(CreateSculptureInputModel createSculptureInputModel)
        {
            var sculpture = new Sculpture
            {
                Name = createSculptureInputModel.Name,
                ImageUrl = createSculptureInputModel.ImageUrl,
                Description = createSculptureInputModel.Description,
                Origin = createSculptureInputModel.Origin,
                Color = createSculptureInputModel.Color,
                SculptureType = createSculptureInputModel.SculptureType,
                Width = createSculptureInputModel.Width,
                Height = createSculptureInputModel.Height,
                Weigth = createSculptureInputModel.Weigth,
                Price = createSculptureInputModel.Price,
                IsMale = createSculptureInputModel.IsMale,
                IsGardenStatue = createSculptureInputModel.IsGardenStatue,
                MaterialId = createSculptureInputModel.MaterialId,
            };

            await this.SculptureRepository.AddAsync(sculpture);
            await this.SculptureRepository.SaveChangesAsync();
        }
    }
}
