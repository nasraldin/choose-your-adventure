using ChooseYourAdventure.Core.Events;
using ChooseYourAdventure.SharedKernel;

namespace ChooseYourAdventure.Core.Entities
{
    public class DecisionTree : BaseEntity
    {
        public DecisionTree()
        {
        }

        /// <summary>
        /// Create new DecisionTree.
        /// </summary>
        /// <param name="treeNodes">TreeNodes for the DecisionTree.</param>
        public DecisionTree(string treeNodes)
        {
            TreeNodes = treeNodes;
        }

        /// <summary>
        /// Get array of TreeNodes.
        /// </summary>
        public string TreeNodes { get; set; }

        /// <summary>
        /// suggested notes for this decision
        /// </summary>
        public string SuggestedNotes { get; set; }

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
