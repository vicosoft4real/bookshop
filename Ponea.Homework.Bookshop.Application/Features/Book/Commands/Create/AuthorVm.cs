using Ponea.Homework.Bookshop.Application.Contracts.Common;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Common.IMapFrom{Ponea.Homework.Bookshop.Domain.Entities.Author}</cref>
    /// </seealso>
    public class AuthorVm : IMapFrom<Domain.Entities.Author>
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
    }
}