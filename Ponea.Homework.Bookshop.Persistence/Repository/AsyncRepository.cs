using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Common;

namespace Ponea.Homework.Bookshop.Persistence.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Ponea.Homework.Bookshop.Application.Contracts.Persistence.IAsyncRepository{T}" />
    public class AsyncRepository<T> : IAsyncRepository<T> where T : AuditableEntity
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly PoneaBookshopDbContext PoneaBookshopContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRepository{T}"/> class.
        /// </summary>
        /// <param name="poneaBookshopContext">The ponea bookshop context.</param>
        public AsyncRepository(PoneaBookshopDbContext poneaBookshopContext)
        {
            this.PoneaBookshopContext = poneaBookshopContext;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAll(int page, int size, CancellationToken cancellationToken = default)
        {
            return await PoneaBookshopContext.Set<T>()
                .Where(x => !x.IsDeleted)
                .Skip((page - 1) * size).Take(size)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<T> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await PoneaBookshopContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            await PoneaBookshopContext.Set<T>().AddAsync(entity, cancellationToken);
            await PoneaBookshopContext.SaveChangesAsync(cancellationToken);

            return entity;

        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await PoneaBookshopContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await PoneaBookshopContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> Update(T entity, CancellationToken cancellationToken = default)
        {
            PoneaBookshopContext.Entry(entity).State = EntityState.Modified;
            await PoneaBookshopContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await PoneaBookshopContext.Set<T>().Where(predicate).ToArrayAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the first or defaultt.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await PoneaBookshopContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}