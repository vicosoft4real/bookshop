using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Delete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Book.Commands.Delete.DeleteBookCommand,
    ///         System.Boolean}
    ///     </cref>
    /// </seealso>
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository bookRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBookCommandHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await bookRepository.Delete(request.Id, cancellationToken);

            return isDeleted;
        }
    }
}