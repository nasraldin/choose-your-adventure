using ChooseYourAdventure.Core.Common.Mappings;
using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.Core.Common.Models
{
    public class TreeNodeVm : IMapFrom<TreeNode>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public int ParentId { get; set; }
    }
}
