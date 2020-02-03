using ChooseYourAdventure.SharedKernel;
using System.Collections.Generic;

namespace ChooseYourAdventure.Core.Entities
{
    public class TreeNode : BaseEntity
    {
        public TreeNode() => TreeNodes = new HashSet<TreeNode>();

        public string Question { get; set; }

        public int? ParentId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<TreeNode> TreeNodes { get; set; }

        public virtual TreeNode Parent { get; set; }
    }
}
