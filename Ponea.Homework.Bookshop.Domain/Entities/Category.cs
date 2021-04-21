using System;
using Ponea.Homework.Bookshop.Domain.Common;

namespace Ponea.Homework.Bookshop.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Ponea.Homework.Bookshop.Domain.Common.AuditableEntity" />
    public class Category : AuditableEntity
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