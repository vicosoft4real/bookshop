using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Persistence.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Persistence.Repository.AsyncRepository{Ponea.Homework.Bookshop.Domain.Entities.Books}</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Persistence.IBookRepository</cref>
    /// </seealso>
    public class BookRepository : AsyncRepository<Books>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="poneaBookshopDb">The ponea bookshop database.</param>
        public BookRepository(PoneaBookshopDbContext poneaBookshopDb) : base(poneaBookshopDb)
        {

        }
        /// <summary>
        /// Gets the name of the books by author.
        /// </summary>
        /// <param name="authName">Name of the authentication.</param>
        /// <returns></returns>
        public async Task<List<Books>> GetBooksByAuthorName(string authName)
        {
            var query = await PoneaBookshopContext.Books.Include(x => x.Authors)
                .Where(x => x.Authors.Any(author => string.Equals(author.FirstName, authName, StringComparison.Ordinal)) || x.Authors.Any(author =>
                     string.Equals(author.LastName, authName, StringComparison.Ordinal))).ToListAsync();

            return query;
        }
        /// <summary>
        /// Gets the books by category.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public async Task<List<Books>> GetBooksByCategory(string categoryName)
        {
            var query = await PoneaBookshopContext.Books.Include(x => x.Category)
                .Where(x => x.Category.Title.Equals(categoryName)).ToListAsync();

            return query;
        }
    }
}