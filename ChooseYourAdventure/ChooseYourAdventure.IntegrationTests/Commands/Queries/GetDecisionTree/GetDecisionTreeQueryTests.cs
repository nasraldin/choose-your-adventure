using AutoMapper;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree;
using ChooseYourAdventure.Infrastructure.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.IntegrationTests.Commands.Queries.GetDecisionTree
{
    [Collection("QueryTests")]
    public class GetDecisionTreeQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDecisionTreeQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetDecisionTreeQuery();

            var handler = new GetDecisionTreeQuery.GetDecisionTreeQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<CategoryDto>();
            result.TreeNodes.Count.ShouldBe(1);
        }
    }
}
