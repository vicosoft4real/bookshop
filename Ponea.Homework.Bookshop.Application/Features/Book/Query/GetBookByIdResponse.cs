using System;
using System.Collections.Generic;
using Ponea.Homework.Bookshop.Application.Contracts.Common;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// </summary>
    public class GetBookResponse : IMapFrom<Books>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
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
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public List<AuthorVm> Authors { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public CateGoryVm Category { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>
        /// The published date.
        /// </value>
        public DateTime PublishedDate { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Common.IMapFrom{Ponea.Homework.Bookshop.Domain.Entities.Author}</cref>
    /// </seealso>
    public class AuthorVm : IMapFrom<Domain.Entities.Author>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Common.IMapFrom{Ponea.Homework.Bookshop.Domain.Entities.Category}</cref>
    /// </seealso>
    public class CateGoryVm : IMapFrom<Domain.Entities.Category>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}