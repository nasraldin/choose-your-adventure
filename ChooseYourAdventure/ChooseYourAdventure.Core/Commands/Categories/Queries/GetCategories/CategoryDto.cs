using ChooseYourAdventure.Core.Common.Mappings;
using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.Core.Commands.Categories.Queries.GetCategories
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
