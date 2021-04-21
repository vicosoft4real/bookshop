using System;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{(System.Boolean Succeed, System.String Message, System.String ValidationError)}</cref>
    /// </seealso>
    public class UpdateBookCommand : IRequest<(bool Succeed, string Message, string[] ValidationError)>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the isbn code.
        /// </summary>
        /// <value>
        /// The isbn code.
        /// </value>
        public string IsbnCode { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>
        /// The published date.
        /// </value>
        public DateTime PublishedDate { get; set; }
    }
}