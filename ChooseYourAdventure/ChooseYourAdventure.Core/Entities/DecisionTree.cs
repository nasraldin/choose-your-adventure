using ChooseYourAdventure.Core.Events;
using ChooseYourAdventure.SharedKernel;

namespace ChooseYourAdventure.Core.Entities
{
    public class DecisionTree : BaseEntity
    {
        /// <summary>
        /// Array of TreeNode Ids.
        /// </summary>
        public string TreeNodes { get; set; }

        /// <summary>
        /// suggested notes for this decision
        /// </summary>
        public string SuggestedNotes { get; set; }

        /// <summary>
        /// CategoryName for current decision
        /// </summary>
        public string CategoryName { get; set; }

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
