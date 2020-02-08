using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.UnitTests
{
    public class DecisionTreeBuilder
    {
        private DecisionTree _decisionTree = new DecisionTree()
        {
            Id = 1,
            TreeNodes = "1,2,3,4"
        };

        public DecisionTreeBuilder Id(int id)
        {
            _decisionTree.Id = id;
            return this;
        }

        public DecisionTreeBuilder TreeNodes(string treeNodes)
        {
            _decisionTree.TreeNodes = treeNodes;
            return this;
        }

        public DecisionTreeBuilder WithDefaultValues()
        {
            _decisionTree = new DecisionTree()
            {
                Id = 1,
                TreeNodes = "1,2,3,4"
            };

            return this;
        }

        public DecisionTree Build() => _decisionTree;
    }
}
