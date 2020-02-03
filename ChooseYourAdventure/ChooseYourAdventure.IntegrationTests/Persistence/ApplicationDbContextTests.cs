using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

// ChooseYourAdventure.Infrastructure.IntegrationTests.Persistence
namespace ChooseYourAdventure.IntegrationTests.Persistence
{
    public class ApplicationDbContextTests : IDisposable
    {
        private readonly ApplicationDbContext _appDb;

        public ApplicationDbContextTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _appDb = new ApplicationDbContext(options);

            _appDb.Categories.Add(new Category
            {
                Name = "Do this thing."
            });

            _appDb.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsync_GivenNewCategory_ShouldSetCreatedProperties()
        {
            var item = new Category
            {
                Name = "Do this thing."
            };

            _appDb.Categories.Add(item);

            await _appDb.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDb?.Dispose();
        }
    }
}
