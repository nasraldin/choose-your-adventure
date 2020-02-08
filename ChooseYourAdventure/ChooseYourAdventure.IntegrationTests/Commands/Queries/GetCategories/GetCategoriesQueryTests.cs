using AutoMapper;
using ChooseYourAdventure.Core.Commands.Categories.Queries.GetCategories;
using ChooseYourAdventure.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.IntegrationTests.Commands.Queries.GetCategories
{
    [Collection("QueryTests")]
    public class GetCategoriesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetCategoriesQuery();

            var handler = new GetCategoriesQuery.GetCategoriesQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(4);
        }
    }
}
