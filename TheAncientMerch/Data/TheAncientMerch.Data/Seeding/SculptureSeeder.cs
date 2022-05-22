namespace TheAncientMerch.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    public class SculptureSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sculptures.Any())
            {
                return;
            }

            var sculptures = new List<Sculpture>
            {
                new Sculpture
                {
                    Name = "Woman of Pride",
                    ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                    Price = 250,
                    Height = 45.50M,
                    Width = 30,
                    Weigth = 10,
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                    Description = "Woman of pride is been in the family for 200 hunders years.",
                    Origin = "Europe",
                    Material = dbContext.SculptureMaterials.Where(x => x.Name == "Cast marble").FirstOrDefault(),
                    Color = Enum.Parse<SculptureColor>("Black"),
                    SculptureType = Enum.Parse<SculptureType>("Busts"),
                },
                new Sculpture
                {
                    Name = "Marcus Aurelius Bust Sculpture",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1551/9675/products/008-SCRO3603002-marcus-aurelius-bust-sculpture_9d16a24e-167c-4fa9-99c7-f75cb1a0ffc5_1800x1800.jpg?v=1652865891",
                    Price = 72,
                    Height = 17,
                    Width = 11.5M,
                    Weigth = 0.57M,
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                    Description = "Marcus Aurelius Bust Sculpture is a reproduction of the famour Marcus Aurelius Antoninus Roman emperor. He was an emperor of Rome from 161 to 180 and he is also famous about his Stoic philosophing. He was the last of the rulers known as the Five Good Emperors, and the last emperor of the Pax Romana, an age of relative peace and stability for the Roman Empire. He served as Roman consul in 140, 145, and 161.",
                    Origin = "Europe",
                    Material = dbContext.SculptureMaterials.Where(x => x.Name == "Bonded marble").FirstOrDefault(),
                    Color = Enum.Parse<SculptureColor>("White"),
                    SculptureType = Enum.Parse<SculptureType>("Busts"),
                },
                new Sculpture
                {
                    Name = "Owl of Athena Bronze Statue",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1551/9675/products/001-owl-of-athena-bronze-statue-SCGR3910050_square_772fc077-eaa6-462a-828b-01052e67d65f_1800x1800.jpg?v=1652862141",
                    Price = 58,
                    Height = 9,
                    Width = 6,
                    Weigth = 0.20M,
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "user").FirstOrDefault(),
                    Description = @"Owl of Athena Bronze Statue with the characteristic ""ΑΘΕ"" inscription, abbreviation of ΑΘΗΝΑΙΩΝ, which may be translated as ""of the Athenians"". A figurine of perfect size for decorating the desk or shelves.",
                    Origin = "Europe",
                    Material = dbContext.SculptureMaterials.Where(x => x.Name == "Cast marble").FirstOrDefault(),
                    Color = Enum.Parse<SculptureColor>("Green"),
                    SculptureType = Enum.Parse<SculptureType>("Statues"),
                },
                new Sculpture
                {
                    Name = "Napoleon with Eagle Bust Sculpture",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1551/9675/products/001-napoleon-with-eagle-bust-sculpture-bronze-SCRO4401218_57f2878e-c3fc-44ca-8b1c-42a1532b3359_1800x1800.jpg?v=1651585155",
                    Price = 290,
                    Height = 30,
                    Width = 19,
                    Weigth = 6,
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "user").FirstOrDefault(),
                    Description = "Napoleon Bonaparte, a bust, with imperial eagle in bronze paint.",
                    Origin = "Europe",
                    Material = dbContext.SculptureMaterials.Where(x => x.Name == "Bronze").FirstOrDefault(),
                    Color = Enum.Parse<SculptureColor>("Brown"),
                    SculptureType = Enum.Parse<SculptureType>("Busts"),
                },
                new Sculpture
                {
                    Name = "Townley Vase on Large Black Pedestal",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1551/9675/products/001-townley-vase-on-large-black-pedestal-SCGR4401134B_1024x1024_3c088b2f-96d3-4a6a-af5e-a05fec16e23e_1800x1800.jpg?v=1651584550",
                    Price = 728,
                    Height = 52,
                    Width = 23,
                    Weigth = 15,
                    AddedByUser = dbContext.Users.Where(x => x.UserName == "user").FirstOrDefault(),
                    Description = "This marble vase, an adapted form of the Greekvolute-krater, is decorated in high relief with a Bacchic scene, featuring the rustic deity Pan, Bacchus, and both male (satyrs) and female (maenads).",
                    Origin = "Europe",
                    Material = dbContext.SculptureMaterials.Where(x => x.Name == "Cast marble").FirstOrDefault(),
                    Color = Enum.Parse<SculptureColor>("White"),
                    SculptureType = Enum.Parse<SculptureType>("Vases"),
                },
            };

            foreach (var item in sculptures)
            {
                await dbContext.Sculptures.AddAsync(new Sculpture
                {
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                    Height = item.Height,
                    Weigth = item.Weigth,
                    Width = item.Width,
                    AddedByUser = item.AddedByUser,
                    Description = item.Description,
                    Origin = item.Origin,
                    Material = item.Material,
                    Color = item.Color,
                    SculptureType = item.SculptureType,
                });
            }
        }
    }
}
