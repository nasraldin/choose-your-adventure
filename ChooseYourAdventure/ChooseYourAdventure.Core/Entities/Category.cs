using ChooseYourAdventure.SharedKernel;
using System.Collections.Generic;

namespace ChooseYourAdventure.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            TreeNodes = new List<TreeNode>();
        }

        public string Name { get; set; }

        /// <summary>
        /// Navigation property for the TreeNode.
        /// </summary>
        public IList<TreeNode> TreeNodes { get; set; }
    }
}
