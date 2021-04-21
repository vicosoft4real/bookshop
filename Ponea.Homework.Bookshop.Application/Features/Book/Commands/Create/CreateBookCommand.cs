using System.Collections.Generic;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Common;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{(System.Boolean succeed, System.String message)}</cref>
    /// </seealso>
    public class CreateBookCommand : IRequest<(bool Succeed, string Id, string[] ValidationError)>, IMapFrom<Books>
    {
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
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public List<AuthorVm> Authors { get; set; }




    }
}