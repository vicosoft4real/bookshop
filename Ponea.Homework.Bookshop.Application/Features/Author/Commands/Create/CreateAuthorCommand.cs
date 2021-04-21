using System.Collections.Generic;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{(System.Boolean succeed, System.String id, System.String[] validationError)}</cref>
    /// </seealso>
    public class CreateAuthorCommand : IRequest<(bool Succeed, string Id, string[] ValidationError)>
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public List<BookVm> Books { get; set; }
    }
}