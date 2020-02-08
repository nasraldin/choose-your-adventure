using AutoMapper;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTrees
{
    public class GetDecisionTreeQuery : IRequest<List<DecisionTreeDto>>
    {
        public class GetDecisionTreeQueryHandler :
            IRequestHandler<GetDecisionTreeQuery, List<DecisionTreeDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDecisionTreeQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DecisionTreeDto>> Handle(GetDecisionTreeQuery request, CancellationToken cancellationToken)
            {
                // get decision data
                var decisionTreeVm = await _context.DecisionTree.ToListAsync().ConfigureAwait(false);

                var decisionTree = new List<DecisionTreeDto>();

                // loop for the trees
                foreach (var item in decisionTreeVm)
                {
                    List<string> treeNodeIds = item.TreeNodes.Split(',').ToList();

                    var treeNodes = _mapper.Map<IList<TreeNodeVm>>(TreeNodeHelper.GetTreeNode(treeNodeIds, _context));

                    decisionTree.Add(new DecisionTreeDto
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName,
                        TreeNodes = treeNodes,
                        SuggestedNotes = item.SuggestedNotes,
                        IsDone = item.IsDone,
                    });
                }

                return decisionTree;
            }
        }
    }
}
