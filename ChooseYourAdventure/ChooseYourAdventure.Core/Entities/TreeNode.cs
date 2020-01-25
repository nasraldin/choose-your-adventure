using ChooseYourAdventure.SharedKernel;

namespace ChooseYourAdventure.Core.Entities
{
    public class TreeNode : BaseEntity
    {
        public string Question { get; set; }

        public int ParentId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
