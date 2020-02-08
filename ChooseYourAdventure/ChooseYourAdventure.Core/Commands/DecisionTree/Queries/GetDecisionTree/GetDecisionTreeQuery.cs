using AutoMapper;
using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Common.Models;
using ChooseYourAdventure.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree
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

                    var treeNodes = _mapper.Map<IList<TreeNodeVm>>(GetTreeNode(treeNodeIds));

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

            /// <summary>
            /// return list of TreeNodes
            /// </summary>
            /// <param name="ids"></param>
            /// <returns></returns>
            public List<TreeNode> GetTreeNode(List<string> ids)
            {
                List<TreeNode> treeNodes = new List<TreeNode>();

                ids.ForEach(x => { treeNodes.Add(_context.TreeNodes.FindAsync(int.Parse(x)).Result); });

                return treeNodes;
            }
        }
    }
}
