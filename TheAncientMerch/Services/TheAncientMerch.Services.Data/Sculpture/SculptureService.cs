namespace TheAncientMerch.Services.Data.Sculpture
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Services.Data.SculptureMaterial;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculptureService : ISculptureService
    {
        private readonly IDeletableEntityRepository<Sculpture> SculptureRepository;
        private readonly ISculptureMaterialService MaterialService;
        private readonly IDeletableEntityRepository<Payment> PaymentRepository;

        public SculptureService(
            IDeletableEntityRepository<Sculpture> sculptureRepository,
            ISculptureMaterialService materialService,
            IDeletableEntityRepository<Payment> paymentRepository)
        {
            this.SculptureRepository = sculptureRepository;
            this.MaterialService = materialService;
            PaymentRepository = paymentRepository;
        }

        public async Task Create(CreateSculptureInputModel createSculptureInputModel, string userId)
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
                MaterialId = createSculptureInputModel.MaterialId,
                AddedByUserId = userId,
            };

            await this.SculptureRepository.AddAsync(sculpture);
            await this.SculptureRepository.SaveChangesAsync();
        }

        public void DeleteSculpture(string userId,int sculptureId)
        {
            throw new System.NotImplementedException();
        }

        public async Task EditSculptureAsync(EditSculptureViewModel model, int sculptureId)
        {
            var sculpture = this.SculptureRepository
                .All()
                .Where(x => x.Id == sculptureId)
                .FirstOrDefault();
            sculpture.Name = model.Name;
            sculpture.ImageUrl = model.ImageUrl;
            sculpture.Description = model.Description;
            sculpture.Origin = model.Origin;
            sculpture.Color = model.Color;
            sculpture.SculptureType = model.SculptureType;
            sculpture.Width = model.Width;
            sculpture.Height = model.Height;
            sculpture.Weigth = model.Weigth;
            sculpture.Price = model.Price;
            sculpture.MaterialId = model.MaterialId;

            this.SculptureRepository.Update(sculpture);
            await this.SculptureRepository.SaveChangesAsync();
        }

        public async Task<SculpturesQueryViewModel> GetAllSculptures(int currentPage, int itemsPerPage, string material, int? sculptureType, int? color)
        {
            var sculpturesQuery = this.SculptureRepository
                .All()
                .Where(x => x.IsDeleted == false && x.IsSold == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(material))
            {
                sculpturesQuery = sculpturesQuery.Where(x => x.Material.Name.ToLower() == material.ToLower());
            }

            if (sculptureType != null)
            {
                sculpturesQuery = sculpturesQuery.Where(x => (int)x.SculptureType == sculptureType);
            }

            if (color != null)
            {
                sculpturesQuery = sculpturesQuery.Where(x => (int)x.Color == color);
            }

            var countSculptures = await sculpturesQuery.CountAsync();

            var sculptures = await sculpturesQuery
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
                })
                .ToListAsync();

            List<string> scupltureMaterials = new List<string>();
            foreach (var sMaterial in this.MaterialService.GetAllMaterials())
            {
                scupltureMaterials.Add(sMaterial.Name);
            }

            return new SculpturesQueryViewModel()
            {
                Sculptures = sculptures,
                ItemsCount = countSculptures,
                PageNumber = currentPage,
                ItemsPerPage = itemsPerPage,
                Materials = scupltureMaterials,
                Color = color,
                Material = material,
                SculptureType = sculptureType,
            };
        }

        public IEnumerable<SculptureViewModel> GetAllUserSculptures(string userId)
        {
            var sculptures = this.SculptureRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
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
                    UserId = x.AddedByUserId,
                })
                .ToList();

            return sculptures;
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
                    UserId = x.AddedByUserId,
                })
                .FirstOrDefault();

            return sculpture;
        }

        public async Task DeleteSculptureAsync(int id)
        {
            var sculpture = this.SculptureRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.SculptureRepository.Delete(sculpture);
            await this.SculptureRepository.SaveChangesAsync();
        }

        public async Task BuySculpture(BuySculptureFormModel model, string userId)
        {
            var sculpture = this.SculptureRepository
                .All()
                .Where(x => x.Id == model.SculptureId)
                .FirstOrDefault();
            sculpture.IsSold = true;

            var payment = new Payment
            {
                BuyerId = userId,
                SculptureId = model.SculptureId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                CardName = model.CardName,
                CardNumber = model.CardNumber,
                Expiration = model.Expiration,
            };

            await this.PaymentRepository.AddAsync(payment);
            await this.PaymentRepository.SaveChangesAsync();

            sculpture.PaymentId = payment.Id;

            this.SculptureRepository.Update(sculpture);
            await this.SculptureRepository.SaveChangesAsync();
        }

        public BuySculptureViewModel GetSculptureForBuyViewModel(int id)
        {
            var sculptureView = this.SculptureRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new BuySculptureViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.AddedByUser.UserName,
                    Price = x.Price,
                })
                .FirstOrDefault();

            return sculptureView;
        }

        public bool ChekIfSculptureIdIsValid(int id)
        {
            var sculpture = this.SculptureRepository
                .All()
                .Where(x => x.Id == id && x.IsDeleted == false && x.IsSold == false)
                .FirstOrDefault();

            return sculpture != null;
        }
    }
}
