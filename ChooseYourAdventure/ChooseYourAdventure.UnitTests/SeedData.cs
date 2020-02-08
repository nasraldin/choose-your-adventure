using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.Infrastructure.Persistence;
using ChooseYourAdventure.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChooseYourAdventure.FunctionalTests
{
    public static class SeedData
    {
        public static readonly List<Category> categories = new List<Category>
        {
            new Category { Name = "Web Development" },
            new Category { Name = "Mobile Development" },
            new Category { Name = "Frontend" },
            new Category { Name = "Backend" },
        };

        public static readonly List<TreeNode> treeNodes = new List<TreeNode>
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

        public static readonly List<DecisionTree> decisionTree = new List<DecisionTree>
        {
            new DecisionTree {
                CategoryName = "Web Development",
                TreeNodes="1,2,3"
            },
            new DecisionTree {
                CategoryName = "Mobile Development" ,
                TreeNodes="1,2,3"
            },
            new DecisionTree {
                CategoryName = "Frontend" ,
                TreeNodes="1,2,3"
            },
        };


        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(), serviceProvider.GetRequiredService<IDomainEventDispatcher>());

            // Look for any items.
            if (dbContext.Categories.Any())
            {
                return; // DB has been seeded
            }

            PopulateTestData(dbContext);
        }

        public static void PopulateTestData(ApplicationDbContext dbContext)
        {
            // reset
            dbContext.RemoveRange(dbContext.Categories, dbContext.TreeNodes);
            dbContext.SaveChanges();

            // add
            dbContext.Categories.AddRange(categories);
            dbContext.TreeNodes.AddRange(treeNodes);
            dbContext.SaveChanges();
        }
    }
}
