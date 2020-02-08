using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Entities;
using System.Collections.Generic;

namespace ChooseYourAdventure.Core.Commands.DecisionTree.Queries
{
    public static class TreeNodeHelper
    {
        /// <summary>
        /// return list of TreeNodes
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<TreeNode> GetTreeNode(List<string> ids, IApplicationDbContext _context)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();

            ids.ForEach(x => { treeNodes.Add(_context.TreeNodes.FindAsync(int.Parse(x)).Result); });

            return treeNodes;
        }
    }
}
