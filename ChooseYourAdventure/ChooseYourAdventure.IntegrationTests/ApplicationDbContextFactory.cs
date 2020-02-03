using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChooseYourAdventure.IntegrationTests
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        {
            context.Categories.AddRange(
                new Category { Name = "Do this thing." },
                new Category { Name = "Do this thing too." },
                new Category { Name = "Do many, many things." },
                new Category { Name = "This thing is done!" }
            );

            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}