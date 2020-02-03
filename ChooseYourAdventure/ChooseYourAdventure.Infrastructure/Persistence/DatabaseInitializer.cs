using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Infrastructure.Persistence
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Categories.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");

                var categories = new List<Category>
                    {
                        new Category { Name = "Web Development" },
                        new Category { Name = "Mobile Development" },
                        new Category { Name = "Frontend" },
                        new Category { Name = "Backend" },
                    };

                _context.Categories.AddRange(categories);
                _logger.LogInformation("Seeding Categories Done!");
            }

            if (!await _context.TreeNodes.AnyAsync())
            {
                var treeNodes = new List<TreeNode>
                    {
                        new TreeNode
                        {
                            Question = "Web Development Question 1",
                            CategoryId = 1
                        },
                        new TreeNode
                        {
                            Question = "Web Development Question 2",
                            CategoryId = 1
                        },
                        new TreeNode
                        {
                            Question = "Web Development Answare Question 1",
                            CategoryId = 1,
                            ParentId = 1
                        },
                        new TreeNode
                        {
                            Question = "Web Development Question Answare Question 3",
                            CategoryId = 1,
                            ParentId = 3
                        },
                        new TreeNode
                        {
                            Question = "Web Development Question 5",
                            CategoryId = 2
                        },
                        new TreeNode
                        {
                            Question = "Web Development Question 6",
                            CategoryId = 2
                        },
                    };

                _context.TreeNodes.AddRange(treeNodes);
                _logger.LogInformation("Seeding Tree Nodes Done!");
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeding initial data completed");
        }
    }
}
