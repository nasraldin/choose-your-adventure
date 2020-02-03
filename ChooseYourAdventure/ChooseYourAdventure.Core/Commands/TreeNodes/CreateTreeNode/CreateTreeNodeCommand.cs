using ChooseYourAdventure.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.TreeNodes.CreateTreeNode
{
    public partial class CreateTreeNodeCommand : IRequest<int>
    {
        public string Question { get; set; }
        public int ParentId { get; set; }
        public int CategoryId { get; set; }

        public class CreateTreeNodeCommandHandler :
            IRequestHandler<CreateTreeNodeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateTreeNodeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateTreeNodeCommand request, CancellationToken cancellationToken)
            {
                var entity = new Entities.TreeNode
                {
                    Question = request.Question,
                    ParentId = request.ParentId,
                    CategoryId = request.CategoryId
                };

                _context.TreeNodes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
