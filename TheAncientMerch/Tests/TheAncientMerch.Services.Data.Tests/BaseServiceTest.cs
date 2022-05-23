namespace TheAncientMerch.Services.Data.Tests
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using TheAncientMerch.Data;

    public class BaseServiceTest
    {
        public static ApplicationDbContext GetDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new ApplicationDbContext(options);

            return db;
        }
    }
}
