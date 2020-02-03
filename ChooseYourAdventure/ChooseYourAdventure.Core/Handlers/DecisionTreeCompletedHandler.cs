using Ardalis.GuardClauses;
using ChooseYourAdventure.Core.Events;
using ChooseYourAdventure.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Handlers
{
    public class DecisionTreeCompletedHandler : IHandle<DecisionTreeCompletedEvent>
    {
        public Task Handle(DecisionTreeCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            return Task.CompletedTask;
        }
    }
}
