using System.Collections.Generic;
using System.Threading.Tasks;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Contracts.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Persistence.IAsyncRepository{Ponea.Homework.Bookshop.Domain.Entities.Books}</cref>
    /// </seealso>
    public interface IBookRepository : IAsyncRepository<Books>
    {
        /// <summary>
        /// Gets the name of the books by author.
        /// </summary>
        /// <param name="authName">Name of the authentication.</param>
        /// <returns></returns>
        Task<List<Books>> GetBooksByAuthorName(string authName);

        /// <summary>
        /// Gets the books by category.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        Task<List<Books>> GetBooksByCategory(string categoryName);

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="authors">The authors.</param>
        /// <returns></returns>
        Task<Books> CreateBook(Books books, List<Author> authors);

    }
}