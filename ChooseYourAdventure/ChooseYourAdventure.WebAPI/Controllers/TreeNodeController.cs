using ChooseYourAdventure.Core.Commands.TreeNodes.CreateTreeNode;
using ChooseYourAdventure.Core.Commands.TreeNodes.Queries.GetTreeNodes;
using ChooseYourAdventure.Core.Entities;
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

        [HttpPost("GetByCategoryId")]
        public async Task<ActionResult<List<TreeNode>>> GetByCategoryId([FromBody]GetTreeNodesQuery query)
        {
            return await Mediator.Send(query).ConfigureAwait(false);
        }
    }
}