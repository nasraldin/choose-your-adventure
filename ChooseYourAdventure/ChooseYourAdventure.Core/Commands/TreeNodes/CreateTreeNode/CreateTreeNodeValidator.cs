using ChooseYourAdventure.Core.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.TreeNodes.CreateTreeNode
{
    public class CreateTreeNodeValidator : AbstractValidator<CreateTreeNodeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTreeNodeValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Question)
                .NotEmpty().WithMessage("Question is required.")
                .MaximumLength(200).WithMessage("Question must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The Question already exists.");

            RuleFor(v => v.CategoryId)
                .NotNull().WithMessage("CategoryId is required.");
        }

        public async Task<bool> BeUniqueTitle(string question, CancellationToken cancellationToken)
        {
            return await _context.TreeNodes.AllAsync(l => l.Question != question);
        }
    }
}
