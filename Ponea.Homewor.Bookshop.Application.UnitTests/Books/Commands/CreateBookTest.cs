using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create;
using Ponea.Homework.Bookshop.Application.Profile;
using Ponea.Homework.Bookshop.Application.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace Ponea.Homework.Bookshop.Application.UnitTests.Books.Commands
{
    public class CreateBookTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IBookRepository> mockBookRepository;

        public CreateBookTest()
        {
            mockBookRepository = AsyncBookRepositoryMock.GetBooksRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Exist_Isbn_Should_Fail()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-853888-2", // exist isbn
                Title = "Advance animation",
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(false);
            createdBook.Id.ShouldBe(string.Empty);
        }

        [Fact]
        public async Task Exist_Title_Should_Fail()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-090129-2",
                Title = "Expert in c# 9",//exist title
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(false);
            createdBook.Id.ShouldBe(string.Empty);
        }

        [Fact]
        public async Task Invalid_Title_Should_Fail_By_Validation()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-090129-2",
                Title = "",//exist title
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(false);
            createdBook.ValidationError.Length.ShouldBe(1);
        }

        [Fact]
        public async Task Invalid_Isbn_Should_Fail_By_Validation()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "",
                Title = "Test",
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(false);
            createdBook.ValidationError.Length.ShouldBe(1);
        }
        [Fact]
        public async Task Book_Without_category_should_fail_by_Validation()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-090129-2",
                Title = "Expert in c# 9",
                CategoryId = Guid.Empty,



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(false);
            createdBook.ValidationError.Length.ShouldBe(1);
        }

        [Fact]
        public async Task Book_With_Non_Exist_Category_should_fail()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-920392032-2",
                Title = "new Expert in c# 9",
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414CCC}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            var allbooks = await mockBookRepository.Object.GetAll(1, 10);

            createdBook.Succeed.ShouldBe(false);
            allbooks.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Book_With_Valid_Request_should_Add_To_Book()
        {
            // arrange

            var handler = new CreateBookHandler(mapper, mockBookRepository.Object);
            var book = new CreateBookCommand()
            {
                IsbnCode = "0-19-190291-2",
                Title = "new Expert in c# 9",
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),



            };

            //act 
            var createdBook = await handler.Handle(book, CancellationToken.None);

            //asset
            createdBook.Succeed.ShouldBe(true);
            var allbooks = await mockBookRepository.Object.GetAll(1, 10);

            allbooks.Count.ShouldBe(4);
        }


    }
}
