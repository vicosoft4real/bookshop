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
    public class GetBookByCategoryName : IRequest<List<GetBookResponse>>
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName { get; set; }
    }
}