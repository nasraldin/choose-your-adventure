using ChooseYourAdventure.Core.Commands.TreeNodes.CreateTreeNode;
using ChooseYourAdventure.Core.Commands.TreeNodes.Queries.GetTreeNodes;
using ChooseYourAdventure.Core.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChooseYourAdventure.WebAPI.Controllers
{
    public class TreeNodeController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateTreeNodeCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<ActionResult<List<TreeNodeVm>>> Get()
        {
            return await Mediator.Send(new GetTreeNodesQuery()).ConfigureAwait(false);
        }
    }
}