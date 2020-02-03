using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.IntegrationTests.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistCategory()
        {
            var command = new CreateCategoryCommand
            {
                Name = "Cat 1"
            };

            var handler = new CreateCategoryCommand.CreateCategoryCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Categories.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }
    }
}
