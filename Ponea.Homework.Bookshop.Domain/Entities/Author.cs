using System;
using System.Collections.Generic;
using Ponea.Homework.Bookshop.Domain.Common;

namespace Ponea.Homework.Bookshop.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Ponea.Homework.Bookshop.Domain.Common.AuditableEntity" />
    public class Author : AuditableEntity
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

        /// <summary>
        /// Gets or sets the book authors.
        /// </summary>
        /// <value>
        /// The book authors.
        /// </value>
        public List<BookAuthor> BookAuthors { get; set; }
    }
}