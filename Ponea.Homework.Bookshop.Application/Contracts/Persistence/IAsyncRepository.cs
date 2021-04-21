using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ponea.Homework.Bookshop.Application.Contracts.Persistence
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAll(int page, int size, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<T> GetById(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<T> Create(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> Delete(string id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> Update(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);



    }
}