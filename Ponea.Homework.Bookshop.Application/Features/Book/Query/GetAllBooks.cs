using System.Collections.Generic;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookResponse}</cref>
    /// </seealso>
    public class GetAllBooksQuery : IRequest<List<GetBookResponse>>
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; set; }

    }
}