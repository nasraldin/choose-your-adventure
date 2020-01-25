using ChooseYourAdventure.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Commands.Categories.CreateCategory
{
    public partial class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler :
            IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = new Core.Entities.Category
                {
                    Name = request.Name
                };

                _context.Categories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
