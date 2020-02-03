using FluentValidation;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.CreateDecisionesTree
{
    public class CreateDecisionTreeValidator : AbstractValidator<CreateDecisionTreeCommand>
    {
        public CreateDecisionTreeValidator()
        {
            RuleFor(v => v.TreeNodes).NotNull().WithMessage("TreeNodes is required.");
        }
    }
}
