using ChooseYourAdventure.Core.Common.Mappings;
using System.Collections.Generic;

namespace ChooseYourAdventure.Core.Common.Models
{
    public class DecisionTreeDto : IMapFrom<Entities.DecisionTree>
    {
        public int Id { get; set; }

        public IList<TreeNodeVm> TreeNodes { get; set; }

        public string SuggestedNotes { get; set; }

        public string CategoryName { get; set; }

        public bool IsDone { get; set; }
    }
}
