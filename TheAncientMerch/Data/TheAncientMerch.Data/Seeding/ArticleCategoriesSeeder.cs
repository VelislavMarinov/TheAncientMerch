namespace TheAncientMerch.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    internal class ArticleCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ArticleCategories.Any())
            {
                return;
            }

            var articleCategories = new List<ArticleCategory>
            {
                new ArticleCategory
                {
                    Name = "Games",
                    ImageUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202104/0517/9AcM3vy5t77zPiJyKHwRfnNT.png",
                },
                new ArticleCategory
                {
                    Name = "Destinations",
                    ImageUrl = "https://www.greecetravelsecrets.com/wp-content/uploads/2020/06/Acropolis-Caryatids-1080x675.jpg",
                },
                new ArticleCategory
                {
                    Name = "Greek Monsters",
                    ImageUrl = "https://i.pinimg.com/originals/c2/d0/ed/c2d0edef764ec8de1603863c2aff6e6a.jpg",
                },
                new ArticleCategory
                {
                    Name = "Greek Demigods",
                    ImageUrl = "https://www.greeklegendsandmyths.com/uploads/5/3/1/3/53133595/peter-paul-rubens-the-calydonian-boar-hunt-google-art-project_orig.jpg",
                },
            };

            foreach (var item in articleCategories)
            {
                await dbContext.ArticleCategories.AddAsync(new ArticleCategory
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                });
            }
        }
    }
}
