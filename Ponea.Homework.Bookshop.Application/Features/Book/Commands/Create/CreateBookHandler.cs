using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, (bool Succeed, string Id, string[] ValidationError)>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Books> asyncRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        public CreateBookHandler(IMapper mapper, IAsyncRepository<Books> asyncRepository)
        {
            this.mapper = mapper;
            this.asyncRepository = asyncRepository;
        }
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool Succeed, string Id, string[] ValidationError)> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidation();

            var validateResult = await validator.ValidateAsync(request, cancellationToken);
            if (validateResult.Errors.Count > 0)
                return (false, "Validation failed", validateResult.Errors.Select(x => x.ErrorMessage).ToArray());

            var exist = await asyncRepository.GetFirstOrDefault(
                (x => x.IsbnCode.Equals(request.IsbnCode) || x.Title.Equals(request.Title) && !x.IsDeleted), cancellationToken);
            if (exist != null) return (false, string.Empty, new[] { "The title or isbn code has already been created" });

            var book = await asyncRepository.Create(mapper.Map<Books>(request), cancellationToken);
            if (book != null && book.Id != Guid.Empty)
                return (true, book.Id.ToString(), Array.Empty<string>());

            return (false, string.Empty, new[] { "The book cannot created at the moment " });



        }
    }
}