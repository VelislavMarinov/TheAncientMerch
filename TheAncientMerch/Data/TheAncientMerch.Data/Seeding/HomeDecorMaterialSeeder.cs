namespace TheAncientMerch.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    internal class HomeDecorMaterialSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.HomeDecorMaterials.Any())
            {
                return;
            }

            var homeDecorMaterials = new List<HomeDecorMaterial>
            {
                new HomeDecorMaterial
                {
                    Name = "Textile",
                },
                new HomeDecorMaterial
                {
                    Name = "Bronze",
                },
                new HomeDecorMaterial
                {
                    Name = "Marble tiles",
                },
                new HomeDecorMaterial
                {
                    Name = "Painting",
                },
                new HomeDecorMaterial
                {
                    Name = "Cast marble",
                },
                new HomeDecorMaterial
                {
                    Name = "Clay",
                },
            };

            foreach (var item in homeDecorMaterials)
            {
                await dbContext.HomeDecorMaterials.AddAsync(new HomeDecorMaterial
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
        }
    }
}
