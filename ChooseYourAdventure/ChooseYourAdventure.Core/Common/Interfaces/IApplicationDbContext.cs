using ChooseYourAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<TreeNode> TreeNodes { get; set; }
        DbSet<DecisionTree> DecisionTree { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
