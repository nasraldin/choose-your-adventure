using ChooseYourAdventure.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Commands.DecisionTrees.CreateDecisionTree
{
    public partial class CreateDecisionTreeCommand : IRequest<int>
    {
        public string TreeNodes { get; }
        public string SuggestedNotes { get; set; }

        public class CreateDecisionTreeCommandHandler : IRequestHandler<CreateDecisionTreeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateDecisionTreeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateDecisionTreeCommand request, CancellationToken cancellationToken)
            {
                var entity = new Core.Entities.DecisionTree(request.TreeNodes)
                {
                    SuggestedNotes = request.SuggestedNotes
                };

                entity.MarkComplete();

                _context.DecisionTree.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
