using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using ChooseYourAdventure.WebAPI;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.UnitTests.Controllers.Category
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenValidCreateCategoryCommand_ReturnsSuccessCode()
        {
            var command = new CreateCategoryCommand
            {
                Name = "Do yet another thing."
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/Category", content);

            response.EnsureSuccessStatusCode();
        }

        //[Fact]
        //public async Task GivenInvalidCreateCategoryCommand_ReturnsBadRequest()
        //{
        //    var command = new CreateCategoryCommand
        //    {
        //        Name = "This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length."
        //    };

        //    var content = IntegrationTestHelper.GetRequestContent(command);

        //    var response = await _client.PostAsync($"/api/Category", content);

        //    response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        //}
    }
}
