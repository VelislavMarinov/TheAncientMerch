namespace TheAncientMerch.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheAncientMerch.Data.Models;

    public class ArticleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            var articles = new List<Article>
            {
                new Article
                {
                    Title = "Hercules",
                    Content = @"Hercules (known in Greek as Heracles or Herakles) is one of the best-known heroes in Greek and Roman mythology. His life was not easy–he endured many trials and completed many daunting tasks–but the reward for his suffering was a promise that he would live forever among the gods at Mount Olympus. Early Life Hercules had a complicated family tree. According to legend, his father was Zeus, ruler of all the gods on Mount Olympus and all the mortals on earth, and his mother was Alcmene, the granddaughter of the hero Perseus. (Perseus, who was also said to be one of Zeus’ sons, famously beheaded the snake-haired Gorgon Medusa.)",
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                    Category = dbContext.ArticleCategories.Where(x => x.Name == "Greek Demigods").FirstOrDefault(),
                    ImageUrl = "https://cdna.artstation.com/p/assets/images/images/026/087/158/medium/furqan-adil-hercules.jpg?1587835855",
                },

                new Article
                {
                    Title = "Medusa",
                    Content = @"According to Hesiod and Aeschylus, she lived and died on Sarpedon, somewhere near Cisthene. The 2nd-century BC novelist Dionysios Skytobrachion puts her somewhere in Libya, where Herodotus had said the Berbers originated her myth as part of their religion.",
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "user").FirstOrDefault(),
                    Category = dbContext.ArticleCategories.Where(x => x.Name == "Greek Monsters").FirstOrDefault(),
                    ImageUrl = "https://i.ytimg.com/vi/Q9pr2Xxaagw/maxresdefault.jpg",
                },

                new Article
                {
                    Title = "Hephaestus Of Lemnos",
                    Content = @"The god of fire, craftsmen, blacksmiths, and volcanoes, Hephaestus is widely described as a child of Hera alone. Mythology says because he was born crippled, Hera threw him out of the heavens. However, as scholar Michael Grant tells us, Hephaestus later received a warm welcome back on Mount Olympus after proving his mettle as a craftsman. According to art historian Nigel McGilchrist, Hephaestus had a soft spot for the volcanic island of Lemnos (Limnos). Today you can visit the important archaeological site on the island, named Hephaestia. According to ancient historian Herodotus, the city of Hephaestia was inhabited by ancestors of the Greeks known as the Pelasgians. The ruins include an impressive Greek theater from the fifth or fourth centuries BCE.",
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                    Category = dbContext.ArticleCategories.Where(x => x.Name == "Destinations").FirstOrDefault(),
                    ImageUrl = "https://thetourguy.com/wp-content/uploads/2021/09/Hephaestus-Lemnos-Limnos-Greece-700-x-425.jpg",
                },
            };

            foreach (var item in articles)
            {
                await dbContext.Articles.AddAsync(new Article
                {
                    Title = item.Title,
                    Content = item.Content,
                    AddedByUser = item.AddedByUser,
                    Category = item.Category,
                    ImageUrl = item.ImageUrl,

                });
            }
        }
    }
}
