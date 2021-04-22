using System;
using MediatR;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Delete
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteBookCommand : IRequest<bool>
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