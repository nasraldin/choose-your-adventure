using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChooseYourAdventure.WebAPI.Controllers
{
    public class DecisionTreeController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> Get()
        {
            return await Mediator.Send(new GetDecisionTreeQuery()).ConfigureAwait(false);
        }
    }
}