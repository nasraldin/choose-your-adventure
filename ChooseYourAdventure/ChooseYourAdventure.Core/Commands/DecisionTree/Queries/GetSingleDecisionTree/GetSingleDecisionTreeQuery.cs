using AutoMapper;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetSingleDecisionTree
{
    public class GetSingleDecisionTreeQuery : IRequest<DecisionTreeDto>
    {
        public int Id { get; set; }

        public class GetSingleDecisionTreeQueryHandler :
            IRequestHandler<GetSingleDecisionTreeQuery, DecisionTreeDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetSingleDecisionTreeQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DecisionTreeDto> Handle(GetSingleDecisionTreeQuery request, CancellationToken cancellationToken)
            {
                var decisionTree = await _context.DecisionTree.FindAsync(request.Id);

                List<string> treeNodeIds = decisionTree.TreeNodes.Split(',').ToList();

                var treeNodes = _mapper.Map<IList<TreeNodeVm>>(TreeNodeHelper.GetTreeNode(treeNodeIds, _context));

                DecisionTreeDto decisionTreeVm = new DecisionTreeDto()
                {
                    Id = decisionTree.Id,
                    CategoryName = decisionTree.CategoryName,
                    SuggestedNotes = decisionTree.SuggestedNotes,
                    IsDone = decisionTree.IsDone,
                    TreeNodes = treeNodes
                };

                return decisionTreeVm;
            }
        }
    }
}
