using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookByIdQuery,
    ///         Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookByIdResponse}
    ///     </cref>
    /// </seealso>
    public class GetByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookResponse>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Books> asyncRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        public GetByIdQueryHandler(IMapper mapper, IAsyncRepository<Books> asyncRepository)
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
        public async Task<GetBookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await asyncRepository.GetById(request.Id, cancellationToken);

            return mapper.Map<GetBookResponse>(book);
        }
    }
}