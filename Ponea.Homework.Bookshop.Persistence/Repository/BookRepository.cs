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
            var query = await PoneaBookshopContext.Books.Include(x => x.BookAuthors)
                .Where(x => x.BookAuthors.Any(author => string.Equals(author.Author.LastName, authName, StringComparison.Ordinal)) || x.BookAuthors.Any(author =>
                     string.Equals(author.Author.LastName, authName, StringComparison.Ordinal))).ToListAsync();

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

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="authors">The authors.</param>
        /// <returns></returns>

        public async Task<Books> CreateBook(Books books, List<Author> authors)
        {
            await PoneaBookshopContext.Books.AddAsync(books);
            await PoneaBookshopContext.SaveChangesAsync();

            foreach (var author in authors)
            {
                PoneaBookshopContext.BookAuthors.Add(new BookAuthor()
                {
                    Author = author,
                    BookId = books.Id

                });
            }

            await PoneaBookshopContext.SaveChangesAsync();
            return books;
        }
    }
}