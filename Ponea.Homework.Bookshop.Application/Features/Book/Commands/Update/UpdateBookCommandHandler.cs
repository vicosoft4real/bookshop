using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update.UpdateBookCommand,
    ///         (System.Boolean Succeed, System.String Message, System.String[] ValidationError)}
    ///     </cref>
    /// </seealso>
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, (bool Succeed, string Message, string[] ValidationError)>
    {
        private readonly IAsyncRepository<Books> asyncRepository;
        private readonly IMapper mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBookCommandHandler"/> class.
        /// </summary>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        /// <param name="mapper"></param>
        public UpdateBookCommandHandler(IAsyncRepository<Books> asyncRepository, IMapper mapper)
        {
            this.asyncRepository = asyncRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool Succeed, string Message, string[] ValidationError)> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookValidator();
            var validateResult = await validator.ValidateAsync(request, cancellationToken);
            if (validateResult.Errors.Count > 0)
                return (false, "Your request validation failed",
                    validateResult.Errors.Select(x => x.ErrorMessage).ToArray());
            var succeed = await asyncRepository.Update(mapper.Map<Books>(request), cancellationToken);
            if (succeed) return (true, "Book has been updated successfully", Array.Empty<string>());

            return (false, "Unable to update book", Array.Empty<string>());

        }
    }
}