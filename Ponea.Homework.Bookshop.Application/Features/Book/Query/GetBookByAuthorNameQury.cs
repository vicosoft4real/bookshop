using System.Collections.Generic;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{System.Collections.Generic.List{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookResponse}}</cref>
    /// </seealso>
    public class GetBookByAuthorNameQuery : IRequest<List<GetBookResponse>>
    {
        /// <summary>
        /// Gets or sets the name of the authentication.
        /// </summary>
        /// <value>
        /// The name of the authentication.
        /// </value>
        public string AuthName { get; set; }
    }
}