using AutoMapper;
using ChooseYourAdventure.Core.Commands.Categories.Queries.GetCategories;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree;
using ChooseYourAdventure.Core.Common.Models;
using ChooseYourAdventure.Core.Entities;
using System;
using Xunit;

namespace ChooseYourAdventure.IntegrationTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        //[Fact]
        //public void ShouldHaveValidConfiguration()
        //{
        //    _configuration.AssertConfigurationIsValid();
        //}

        [Theory]
        [InlineData(typeof(Category), typeof(CategoryDto))]
        [InlineData(typeof(TreeNode), typeof(TreeNodeVm))]
        [InlineData(typeof(DecisionTree), typeof(DecisionTreeDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
