using System;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookByIdResponse}</cref>
    /// </seealso>
    public class GetBookByIdQuery : IRequest<GetBookResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}