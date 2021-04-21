using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;

namespace Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create.CreateAuthorCommand,
    ///         (System.Boolean Succeed, System.String Id, System.String[] ValidationError)}
    ///     </cref>
    /// </seealso>
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, (bool Succeed, string Id, string[] ValidationError)>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Domain.Entities.Author> asyncRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAuthorCommandHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        public CreateAuthorCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Author> asyncRepository)
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
        public async Task<(bool Succeed, string Id, string[] ValidationError)> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorCommandValidation();
            var validateResult = await validator.ValidateAsync(request, cancellationToken);
            if (validateResult.Errors.Count > 0)
                return (false, string.Empty, validateResult.Errors.Select(x => x.ErrorMessage).ToArray());
            var entity = await asyncRepository.Create(mapper.Map<Domain.Entities.Author>(request), cancellationToken);
            return (true, entity?.Id.ToString(), Array.Empty<string>());




        }
    }
}