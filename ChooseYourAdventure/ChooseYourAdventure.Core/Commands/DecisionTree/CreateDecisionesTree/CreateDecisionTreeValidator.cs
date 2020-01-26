using ChooseYourAdventure.Commands.DecisionTrees.CreateDecisionTree;
using FluentValidation;

namespace ChooseYourAdventure.Commands.DecisionTree.CreateDecisionTree
{
    public class CreateDecisionTreeValidator : AbstractValidator<CreateDecisionTreeCommand>
    {
        public CreateDecisionTreeValidator()
        {
            RuleFor(v => v.TreeNodes).NotNull().WithMessage("TreeNodes is required.");
        }
    }
}
