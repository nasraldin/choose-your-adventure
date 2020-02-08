using ChooseYourAdventure.Core.Commands.DecisionTree.CreateDecisionesTree;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTree;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChooseYourAdventure.WebAPI.Controllers
{
    public class DecisionTreeController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDecisionTreeCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<ActionResult<List<DecisionTreeDto>>> Get()
        {
            return await Mediator.Send(new GetDecisionTreeQuery()).ConfigureAwait(false);
        }
    }
}