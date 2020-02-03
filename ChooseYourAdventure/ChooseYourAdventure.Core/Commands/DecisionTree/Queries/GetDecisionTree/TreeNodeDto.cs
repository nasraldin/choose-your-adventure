using AutoMapper;
using ChooseYourAdventure.Core.Common.Mappings;
using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree
{
    public class TreeNodeDto : IMapFrom<TreeNode>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public int ParentId { get; set; }

        public int CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TreeNode, TreeNodeDto>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.CategoryId));
        }
    }
}
