using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.TreeNodes.Queries.GetTreeNodes
{
    public class GetTreeNodesQuery : IRequest<List<TreeNodeVm>>
    {
        public class GetTreeNodesQueryHandler :
            IRequestHandler<GetTreeNodesQuery, List<TreeNodeVm>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTreeNodesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TreeNodeVm>> Handle(GetTreeNodesQuery request, CancellationToken cancellationToken)
            {
                return await _context.TreeNodes.ProjectTo<TreeNodeVm>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
        }
    }
}
