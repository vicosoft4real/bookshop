using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Application.Features.Book.Query;
using Ponea.Homework.Bookshop.Application.Profile;
using Ponea.Homework.Bookshop.Application.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace Ponea.Homework.Bookshop.Application.UnitTests.Books.Query
{
    public class BookQueryTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IAsyncRepository<Domain.Entities.Books>> mockBookRepository;

        public BookQueryTest()
        {
            mockBookRepository = AsyncBookRepositoryMock.GetBooksRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_Book_by_id_should_return_the_book()
        {
            // arrange

            var handler = new GetByIdQueryHandler(mapper, mockBookRepository.Object);
            var id = new GetBookByIdQuery() { Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}") };

            //act 
            var book = await handler.Handle(id, CancellationToken.None);

            //asset
            book.ShouldBeOfType<GetBookResponse>();

        }


        [Fact]
        public async Task GetAll_Book_should_return_All_book()
        {
            // arrange

            var handler = new GetAllBooksHandler(mockBookRepository.Object, mapper);
            var query = new GetAllBooksQuery() { Page = 1, Size = 10 };

            //act 
            var books = await handler.Handle(query, CancellationToken.None);

            //asset
            books.ShouldBeOfType<List<GetBookResponse>>();
            books.Count.ShouldBe(3);

        }
    }
}