using System.Collections.Generic;
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
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetAllBooksQuery,
    ///         System.Collections.Generic.List{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookResponse}}
    ///     </cref>
    /// </seealso>
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<GetBookResponse>>
    {
        private readonly IAsyncRepository<Books> asyncRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllBooksHandler"/> class.
        /// </summary>
        /// <param name="asyncRepository">The asynchronous repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetAllBooksHandler(IAsyncRepository<Books> asyncRepository, IMapper mapper)
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
        public async Task<List<GetBookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var query = await asyncRepository.GetAll(request.Page, request.Size, cancellationToken);

            return mapper.Map<List<GetBookResponse>>(query);
        }
    }
}