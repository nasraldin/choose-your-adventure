using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.UnitTests
{
    public class TreeNodeBuilder
    {
        private TreeNode _treeNode = new TreeNode();

        public TreeNodeBuilder Id(int id)
        {
            _treeNode.Id = id;
            return this;
        }

        public TreeNodeBuilder Question(string question)
        {
            _treeNode.Question = question;
            return this;
        }

        public TreeNodeBuilder ParentId(int parentId)
        {
            _treeNode.ParentId = parentId;
            return this;
        }

        public TreeNodeBuilder CategoryId(int categoryId)
        {
            _treeNode.CategoryId = categoryId;
            return this;
        }

        public TreeNodeBuilder WithDefaultValues()
        {
            _treeNode = new TreeNode()
            {
                Id = 1,
                Question = "Test Question",
                ParentId = 1,
                CategoryId = 1
            };

            return this;
        }

        public TreeNode Build() => _treeNode;
    }
}
