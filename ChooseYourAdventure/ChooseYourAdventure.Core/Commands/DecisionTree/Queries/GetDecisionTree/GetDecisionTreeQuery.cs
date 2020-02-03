using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree
{
    public class GetDecisionTreeQuery : IRequest<CategoryDto>
    {
        public class GetDecisionTreeQueryHandler :
            IRequestHandler<GetDecisionTreeQuery, CategoryDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDecisionTreeQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetDecisionTreeQuery request, CancellationToken cancellationToken)
            {
                var vm = new CategoryDto();

                vm.TreeNodes = await _context.TreeNodes
                    .ProjectTo<TreeNodeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}
