using ChooseYourAdventure.Core.Common.Mappings;
using ChooseYourAdventure.Core.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.DecisionTree.Queries.GetDecisionTree
{
    public class CategoryDto : IMapFrom<Category>
    {
        public CategoryDto()
        {
            TreeNodes = new List<TreeNodeDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<TreeNodeDto> TreeNodes { get; set; }
    }
}
