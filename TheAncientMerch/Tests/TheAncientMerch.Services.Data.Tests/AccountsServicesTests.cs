namespace TheAncientMerch.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TheAncientMerch.Data;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Data.Repositories;
    using TheAncientMerch.Services.Data.Accounts;
    using Xunit;

    public class AccountsServicesTests : BaseServiceTest
    {

        [Fact]
        public async Task GetAccountViewModelShouldReturnCorrectData()
        {
            ApplicationDbContext db = GetDatabase();
            var accountsRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var paymentRepository = new EfDeletableEntityRepository<Payment>(db);

            var accountService = new AccountService(accountsRepository,paymentRepository);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@gosho.com",
            };

            var user2 = new ApplicationUser
            {
                Id = "x333",
                UserName = "gosho",
                Email = "gosho@gosho.com",
            };

            var user3 = new ApplicationUser
            {
                Id = "x444",
                UserName = "ivan",
                Email = "ivan@ivan.com",
            };

            await db.Users.AddAsync(user);
            await db.Users.AddAsync(user2);
            await db.Users.AddAsync(user3);
            await db.SaveChangesAsync();

            var result = accountService.GetAccountViewModel("x222");
            var result2 = accountService.GetAccountViewModel("x444");

            Assert.Equal(result.Username, user.UserName);
            Assert.Equal(result2.Username, user3.UserName);
        }

        [Fact]
        public async Task GetUserBoughtSculpturesPaymentsShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var accountsRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var paymentRepository = new EfDeletableEntityRepository<Payment>(db);
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);

            var accountService = new AccountService(accountsRepository, paymentRepository);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@gosho.com",
            };
            var user2 = new ApplicationUser
            {
                Id = "x333",
                UserName = "pesho",
                Email = "pesho@gosho.com",
            };
            await db.Users.AddAsync(user);
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();
            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x333",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var payment = new Payment
            {
                BuyerId = user.Id,
                SculptureId = 1,
                FirstName = "Gosho",
                LastName = "Petrov",
                PhoneNumber = "09999312",
                Email = "gosho@petrov.gp",
                Address = "Bulgaria 5722 home city",
                CardName = "Gosho",
                CardNumber = "03131231",
                Expiration = "01/12",
            };

            await db.Payments.AddAsync(payment);
            await db.SaveChangesAsync();

            var result = accountService.GetUserBoughtSculpturesPayments("x222");

            Assert.True(result.Count() == 1);
            Assert.Contains(result, x => x.BuyerName == user.UserName);
        }

        [Fact]
        public async Task GetUserSoldSculpturesPaymentsShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDatabase();
            var accountsRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var paymentRepository = new EfDeletableEntityRepository<Payment>(db);
            var sculptureRepostirory = new EfDeletableEntityRepository<Sculpture>(db);

            var accountService = new AccountService(accountsRepository, paymentRepository);

            var user = new ApplicationUser
            {
                Id = "x222",
                UserName = "pesho",
                Email = "pesho@gosho.com",
            };
            var user2 = new ApplicationUser
            {
                Id = "x333",
                UserName = "pesho",
                Email = "pesho@gosho.com",
            };
            await db.Users.AddAsync(user);
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();
            var material = new SculptureMaterial
            {
                Name = "Marble",
            };

            await db.SculptureMaterials.AddAsync(material);
            await db.SaveChangesAsync();

            var sculpture1 = new Sculpture
            {
                Id = 1,
                Name = "Woman of Pride",
                ImageUrl = "https://cb2.scene7.com/is/image/CB2/JudyTheBustSHF16/$web_pdp_main_carousel_xs$/190905021514/judy-bust-statue.jpg",
                Price = 250,
                Height = 45.50M,
                Width = 30,
                Weigth = 10,
                AddedByUserId = "x222",
                Description = "Woman of pride is been in the family for 200 hunders years.",
                Origin = "Europe",
                Material = material,
                Color = Enum.Parse<SculptureColor>("Black"),
                SculptureType = Enum.Parse<SculptureType>("Statues"),
            };

            await db.Sculptures.AddAsync(sculpture1);
            await db.SaveChangesAsync();

            var payment = new Payment
            {
                BuyerId = user2.Id,
                SculptureId = 1,
                FirstName = "Gosho",
                LastName = "Petrov",
                PhoneNumber = "09999312",
                Email = "gosho@petrov.gp",
                Address = "Bulgaria 5722 home city",
                CardName = "Gosho",
                CardNumber = "03131231",
                Expiration = "01/12",
            };

            await db.Payments.AddAsync(payment);
            await db.SaveChangesAsync();

            var result = accountService.GetUserSoldSculpturesPayments("x222");

            Assert.True(result.Count() == 1);
            Assert.Contains(result, x => x.BuyerName == user2.UserName);
        }
    }
}
