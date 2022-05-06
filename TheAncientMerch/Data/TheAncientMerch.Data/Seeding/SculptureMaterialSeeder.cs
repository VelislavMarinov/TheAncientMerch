namespace TheAncientMerch.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    internal class SculptureMaterialSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SculptureMaterials.Any())
            {
                return;
            }

            var sculptureMaterials = new List<SculptureMaterial>
            {
                new SculptureMaterial
                {
                    Name = "Bronze",
                },
                new SculptureMaterial
                {
                    Name = "Cast marble",
                },
                new SculptureMaterial
                {
                    Name = "Bonded marble",
                },
                new SculptureMaterial
                {
                    Name = "Alabaster",
                },
            };

            foreach (var item in sculptureMaterials)
            {
                await dbContext.SculptureMaterials.AddAsync(new SculptureMaterial
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
        }
    }
}
