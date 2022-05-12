namespace TheAncientMerch.Services.Data.Sculpture
{
    using System.Collections.Generic;
    using System.Linq;
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

        public void DeleteSculpture(string userId,int sculptureId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SculptureViewModel> GetAllSculptures(int currentPage, int itemsPerPage)
        {
            var sculptures = this.SculptureRepository
                .All()
                .OrderByDescending(x => x.Id)
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new SculptureViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Color = x.Color.ToString(),
                    Material = x.Material.Name,
                    Description = x.Description,
                    Origin = x.Origin,
                    Width = x.Width,
                    Height = x.Height,
                    Weigth = x.Weigth,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    SculptureType = x.SculptureType.ToString(),
                });

            return sculptures;
        }

        public IEnumerable<SculptureViewModel> GetAllUserSculptures()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            var count = this.SculptureRepository.All().Count();
            return count;
        }

        public SculptureViewModel GetSculptureById(int id)
        {
            var sculpture = this.SculptureRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new SculptureViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Color = x.Color.ToString(),
                    Material = x.Material.Name,
                    Description = x.Description,
                    Origin = x.Origin,
                    Width = x.Width,
                    Height = x.Height,
                    Weigth = x.Weigth,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    SculptureType = x.SculptureType.ToString(),
                })
                .FirstOrDefault();

            return sculpture;
        }


    }
}
