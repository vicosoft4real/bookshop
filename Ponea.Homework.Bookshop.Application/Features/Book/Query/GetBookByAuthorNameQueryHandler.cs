using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookByAuthorNameQuery,
    ///         System.Collections.Generic.List{Ponea.Homework.Bookshop.Application.Features.Book.Query.GetBookResponse}}
    ///     </cref>
    /// </seealso>
    public class GetBookByAuthorNameQueryHandler : IRequestHandler<GetBookByAuthorNameQuery, List<GetBookResponse>>
    {
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBookByAuthorNameQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="bookRepository">The book repository.</param>
        public GetBookByAuthorNameQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            this.mapper = mapper;
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
        public async Task<List<GetBookResponse>> Handle(GetBookByAuthorNameQuery request, CancellationToken cancellationToken)
        {
            var quey = await bookRepository.GetBooksByAuthorName(request.AuthName);

            return mapper.Map<List<GetBookResponse>>(quey);
        }
    }
}