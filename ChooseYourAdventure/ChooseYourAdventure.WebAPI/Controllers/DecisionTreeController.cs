using ChooseYourAdventure.Core.Commands.DecisionTree.CreateDecisionesTree;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetDecisionTrees;
using ChooseYourAdventure.Core.Commands.DecisionTree.Queries.GetSingleDecisionTree;
using ChooseYourAdventure.Core.Common.Models;
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

        [HttpPost("Details")]
        public async Task<ActionResult<DecisionTreeDto>> Details([FromBody]GetSingleDecisionTreeQuery query)
        {
            return await Mediator.Send(query).ConfigureAwait(false);
        }
    }
}