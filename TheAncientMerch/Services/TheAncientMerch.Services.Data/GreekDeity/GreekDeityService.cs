namespace TheAncientMerch.Services.Data.GreekDeity
{
    using System;

    using System.Linq;

    using System.Collections.Generic;

    using TheAncientMerch.Data.Common.Repositories;

    using TheAncientMerch.Data.Models;

    using TheAncientMerch.Web.ViewModels.GreekDeitys;

    public class GreekDeityService : IGreekDeityService
    {
        private readonly IRepository<GreekDeity> greekDeityRepository;

        public GreekDeityService(IRepository<GreekDeity> greekDeityRepository)
        {
            this.greekDeityRepository = greekDeityRepository;
        }

        public IEnumerable<DeityViewModel> GetAllGods()
        {
            var gods = this.greekDeityRepository
                .All()
                .Where(x => x.Type == DeityType.God)
                .Select(x => new DeityViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                });

            return gods;
        }

        public IEnumerable<DeityViewModel> GetAllTitans()
        {
            var titans = this.greekDeityRepository
                .All()
                .Where(x => x.Type == DeityType.Titan)
               .Select(x => new DeityViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   ImageUrl = x.ImageUrl,
                   VideoUrl = x.VideoUrl,
               });

            return titans;
        }

        public DeityViewModel GetDeity(int id)
        {
            var deity = this.greekDeityRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new DeityViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                })
                .FirstOrDefault();

            return deity;
        }
    }
}
