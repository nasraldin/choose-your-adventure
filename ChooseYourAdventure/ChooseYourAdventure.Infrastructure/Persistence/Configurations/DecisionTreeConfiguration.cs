using ChooseYourAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChooseYourAdventure.Infrastructure.Persistence.Configurations
{
    public class DecisionTreeConfiguration : IEntityTypeConfiguration<DecisionTree>
    {
        public void Configure(EntityTypeBuilder<DecisionTree> builder)
        {
            builder.Property(t => t.TreeNodes).IsRequired();
        }
    }
}
