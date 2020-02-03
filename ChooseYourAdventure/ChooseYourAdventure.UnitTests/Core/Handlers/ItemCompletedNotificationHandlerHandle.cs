using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.Core.Events;
using ChooseYourAdventure.Core.Handlers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourAdventure.UnitTests.Core.Handlers
{
    public class ItemCompletedNotificationHandlerHandle
    {
        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            var handler = new DecisionTreeCompletedHandler();

            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null));
        }

        [Fact]
        public async Task DoesNothingGivenEventInstance()
        {
            var handler = new DecisionTreeCompletedHandler();

            await handler.Handle(new DecisionTreeCompletedEvent(new DecisionTree()));
        }
    }
}
