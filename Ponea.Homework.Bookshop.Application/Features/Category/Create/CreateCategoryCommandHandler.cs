using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;

namespace Ponea.Homework.Bookshop.Application.Features.Category.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Category.Create.CreateCategoryCommand,
    ///         (System.Boolean Succeed, System.String Id, System.String[] ValidationError)}
    ///     </cref>
    /// </seealso>
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, (bool Succeed, string Id, string[] ValidationError)>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Domain.Entities.Category> asyncRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Category> asyncRepository)
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
        public async Task<(bool Succeed, string Id, string[] ValidationError)> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                return (false, string.Empty, validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            var entity = await asyncRepository.Create(mapper.Map<Domain.Entities.Category>(request), cancellationToken);
            return (true, entity?.Id.ToString(), Array.Empty<string>());


        }
    }
}