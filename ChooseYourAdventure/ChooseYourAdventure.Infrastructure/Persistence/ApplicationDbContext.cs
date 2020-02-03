using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Core.Entities;
using ChooseYourAdventure.SharedKernel;
using ChooseYourAdventure.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //private readonly IDomainEventDispatcher _dispatcher;

        // , IDomainEventDispatcher dispatcher
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_dispatcher = dispatcher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TreeNode> TreeNodes { get; set; }
        public DbSet<DecisionTree> DecisionTree { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<TreeNode>()
            .HasOne(p => p.Parent)
            .WithMany(p => p.TreeNodes)
            .HasForeignKey(p => p.ParentId);


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            //if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    //await _dispatcher.Dispatch(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
