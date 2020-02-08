using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.UnitTests;
using ChooseYourAdventure.WebAPI;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.FunctionalTests.Api
{
    public class DecisionTreeControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public DecisionTreeControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task EnsureSuccessOk()
        {
            var response = await _client.GetAsync("/api/DecisionTree");
            Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
        }

        [Fact]
        public void ReturnsSameObject()
        {
            Assert.IsType<List<DecisionTree>>(SeedData.decisionTree);
        }
    }
}
