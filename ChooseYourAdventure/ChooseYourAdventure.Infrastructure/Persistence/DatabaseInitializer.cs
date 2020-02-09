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
                        new Category { Name = "Desktop Development" },
                        new Category { Name = "Embedded System" },
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
                            Question = "Have you familiar with web development?",
                            CategoryId = 1
                        },
                        new TreeNode
                        {
                            Question = "Do you know JavaScript?",
                            CategoryId = 1
                        },
                        new TreeNode
                        {
                            Question = "Do you know HTML5 SASS?",
                            CategoryId = 1
                        },

                        new TreeNode
                        {
                            Question = "Have you familiar with Mobile development?",
                            CategoryId = 2,
                        },
                        new TreeNode
                        {
                            Question = "Do you know kotlin?",
                            CategoryId = 2,
                        },
                        new TreeNode
                        {
                            Question = "Do you know Flutter?",
                            CategoryId = 2
                        },
                        new TreeNode
                        {
                            Question = "JavaScript is the best?",
                            CategoryId = 1,
                            ParentId = 2
                        },
                        new TreeNode
                        {
                            Question = "Familiar with input types in HTML5?",
                            CategoryId = 1,
                            ParentId = 3
                        },
                    };

                _context.TreeNodes.AddRange(treeNodes);
                _logger.LogInformation("Seeding Tree Nodes Done!");
                _logger.LogInformation("Seeding initial data completed");
            }

            await _context.SaveChangesAsync();
        }
    }
}
