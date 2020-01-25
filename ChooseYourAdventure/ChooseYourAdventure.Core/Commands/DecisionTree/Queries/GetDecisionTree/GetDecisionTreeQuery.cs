using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChooseYourAdventure.Core.Common.Interfaces;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DecisionTree.Queries.GetDecisionTree
{
    public class GetDecisionTreeQuery : IRequest<DecisionTreeVm>
    {
        public class GetDecisionTreeQueryHandler :
            IRequestHandler<GetDecisionTreeQuery, DecisionTreeVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDecisionTreeQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DecisionTreeVm> Handle(GetDecisionTreeQuery request, CancellationToken cancellationToken)
            {
                return new DecisionTreeVm
                {
                    DecisionTree = await _context.DecisionTree
                    .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}
