using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ponea.Homework.Bookshop.Application.Contracts.Identity;
using Ponea.Homework.Bookshop.Domain.Common;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Persistence
{
    /// <summary>
    /// /
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class PoneaBookshopDbContext : DbContext
    {

        private readonly ILoggedInUserService loggedInUserService;


        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public DbSet<Books> Books { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PoneaBookshopDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="loggedInUserService"></param>
        public PoneaBookshopDbContext(DbContextOptions<PoneaBookshopDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {

            this.loggedInUserService = loggedInUserService;
        }
        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoneaBookshopDbContext).Assembly);


        }

        /// <summary>
        /// <para>
        /// Saves all changes made in this context to the database.
        /// </para>
        /// <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        /// changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </para>
        /// <para>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.DateCreated = DateTime.Now;
                        entity.Entity.CreatedBy = loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.Now;
                        entity.Entity.LastModifiedBy = loggedInUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}