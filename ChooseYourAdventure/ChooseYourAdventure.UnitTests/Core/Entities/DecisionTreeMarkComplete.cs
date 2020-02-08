using ChooseYourAdventure.Core.Entities;
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
            var decisionTree = new DecisionTree()
            {
                Id = 1,
                TreeNodes = "1,2,3,4"
            };
            decisionTree.MarkComplete();

            Assert.NotNull(item);
            Assert.IsType<DecisionTreeCompletedEvent>(decisionTree.Events.First());
        }
    }
}
