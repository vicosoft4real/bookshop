using System;
using System.Collections.Generic;
using Ponea.Homework.Bookshop.Domain.Common;

namespace Ponea.Homework.Bookshop.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Ponea.Homework.Bookshop.Domain.Common.AuditableEntity" />
    public class Books : AuditableEntity
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
        public List<Author> Authors { get; set; }

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
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>
        /// The published date.
        /// </value>
        public DateTime PublishedDate { get; set; }
    }
}