using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.SharedKernel;

namespace ChooseYourAdventure.Core.Events
{
    public class DecisionTreeCompletedEvent : BaseDomainEvent
    {
        public DecisionTree CompletedItem { get; set; }

        public DecisionTreeCompletedEvent(DecisionTree completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}
