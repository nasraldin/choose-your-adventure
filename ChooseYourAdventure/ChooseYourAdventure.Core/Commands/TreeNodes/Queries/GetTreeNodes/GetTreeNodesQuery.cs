using AutoMapper;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.TreeNodes.Queries.GetTreeNodes
{
    public class GetTreeNodesQuery : IRequest<List<TreeNode>>
    {
        public int Id { get; set; }

        public class GetTreeNodesQueryHandler :
            IRequestHandler<GetTreeNodesQuery, List<TreeNode>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTreeNodesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TreeNode>> Handle(GetTreeNodesQuery request, CancellationToken cancellationToken)
            {
                return await _context.TreeNodes.Where(n => n.CategoryId == request.Id).ToListAsync(cancellationToken);
            }
        }
    }
}
