using ChooseYourAdventure.SharedKernel;
using ChooseYourAdventure.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace ChooseYourAdventure.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
