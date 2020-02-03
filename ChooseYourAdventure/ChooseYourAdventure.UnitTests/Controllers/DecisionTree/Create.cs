using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using ChooseYourAdventure.WebAPI;
using Shouldly;
using System.Net;
using System.Threading.Tasks;
using Xunit;

// ChooseYourAdventure.WebAPI.IntegrationTests.Controllers.DecisionTree
namespace ChooseYourAdventure.UnitTests.Controllers.DecisionTree
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateCategoryCommand_ReturnsSuccessCode()
        {
            var command = new CreateCategoryCommand
            {
                Name = "Do yet another thing."
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await _factory.Server.CreateClient()
                .PostAsync($"/api/DecisionTree", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateCategoryCommand_ReturnsBadRequest()
        {
            var client = _factory.Server.CreateClient();

            var command = new CreateCategoryCommand
            {
                Name = "This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length."
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/DecisionTree", content);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}
