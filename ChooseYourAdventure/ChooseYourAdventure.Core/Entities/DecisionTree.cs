using ChooseYourAdventure.Core.Events;
using ChooseYourAdventure.SharedKernel;

namespace ChooseYourAdventure.Core.Entities
{
    public class DecisionTree : BaseEntity
    {
        /// <summary>
        /// Create new DecisionTree.
        /// </summary>
        /// <param name="treeNodes">TreeNodes for the DecisionTree.</param>
        public DecisionTree(int[] treeNodes)
        {
            TreeNodes = treeNodes;
        }

        /// <summary>
        /// Get array of TreeNodes.
        /// </summary>
        public int[] TreeNodes { get; }

        /// <summary>
        /// Mark DecisionTree of TreeNodes IsDone.
        /// </summary>
        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new DecisionTreeCompletedEvent(this));
        }
    }
}
