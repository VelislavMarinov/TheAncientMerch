namespace TheAncientMerch.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    internal class ForumCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            var forumCategorys = new List<ForumCategory>
            {
               new ForumCategory
               {
                    Name = "Games",
                    Description = "Lets talk about all God of War games.",
               },
               new ForumCategory
               {
                    Name = "Demigods",
                    Description = "Lets talk about Hercules and achiles",
               },
               new ForumCategory
               {
                    Name = "Titans",
                    Description = "Lets talk about Titans and how strong were they",
               },
               new ForumCategory
               {
                    Name = "Athena and Poseidon",
                    Description = "What is the relationship of Athena and Poseidon",
               },
               new ForumCategory
               {
                    Name = "Hades",
                    Description = "Do you think Hades was stronger than Zeus?",
               },
            };

            foreach (var item in forumCategorys)
            {
                await dbContext.ForumCategories.AddAsync(new ForumCategory
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                });
            }
        }
    }
}
