using ChooseYourAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChooseYourAdventure.Infrastructure.Persistence.Configurations
{
    public class TreeNodeConfiguration : IEntityTypeConfiguration<TreeNode>
    {
        public void Configure(EntityTypeBuilder<TreeNode> builder)
        {
            builder.Property(t => t.Question).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();
        }
    }
}
