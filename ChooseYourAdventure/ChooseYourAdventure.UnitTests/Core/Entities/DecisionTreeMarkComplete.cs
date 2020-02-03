using ChooseYourAdventure.Core.Events;
using System.Linq;
using Xunit;

namespace ChooseYourAdventure.UnitTests.Core.Entities
{
    public class DecisionTreeMarkComplete
    {
        [Fact]
        public void SetsIsDoneToTrue()
        {
            var item = new DecisionTreeBuilder()
                .WithDefaultValues()
                .TreeNodes("")
                .Build();

            item.MarkComplete();

            Assert.True(item.IsDone);
        }

        [Fact]
        public void RaisesDecisionTreeCompletedEvent()
        {
            var item = new DecisionTreeBuilder().Build();

            item.MarkComplete();

            Assert.Single(item.Events, item.Events);
            Assert.IsType<DecisionTreeCompletedEvent>(item.Events.First());
        }
    }
}
