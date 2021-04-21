using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Moq;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homewor.Bookshop.Application.UnitTests.Mocks
{
    public class AsyncBookRepositoryMock
    {
        public static Mock<IAsyncRepository<Books>> GetBooksRepository()
        {
            var books = new List<Books>()
            {
                new()
                {
                    IsbnCode = "0-19-853888-2",
                    Title = "Expert in c# 9",
                    PublishedDate = new DateTime(2019, 09, 2),
                    Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    Authors = new List<Author>()
                    {
                        new()
                        {
                            Id = Guid.Parse("{E45202D7-F92D-4CB7-9302-A5EBEE99B1C7}"),
                            FirstName = "Adebayo",
                            LastName = "Sogo",

                        },
                        new()
                        {
                            Id = Guid.Parse("{FD8A6434-6485-4CED-8D17-03FFCFC4D7FF}"),
                            FirstName = "Samson",
                            LastName = "Godwin",

                        }
                    },
                    Category = new Category()
                    {
                        Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                        Title = "Software Engineering"
                    }



                },
                new()
                {
                    IsbnCode = "0-19-853808-2",
                    Title = "Advance design pattern in c#",
                    PublishedDate = new DateTime(2021, 04, 2),
                    Id = Guid.Parse("{F1DFAD86-1A91-4E84-8AF9-C416108A10E6}"),
                    Authors = new List<Author>()
                    {
                        new()
                        {
                            Id = Guid.Parse("{E45202D7-F92D-4CB7-9302-A5EBEE99B1C7}"),
                            FirstName = "Adebayo",
                            LastName = "Sogo",

                        },
                        new()
                        {
                            Id = Guid.Parse("{FD8A6434-6485-4CED-8D17-03FFCFC4D7FF}"),
                            FirstName = "Samson",
                            LastName = "Godwin",

                        }
                    },
                    Category = new Category()
                    {
                        Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                        Title = "Software Engineering"
                    }



                },
                new()
                {
                IsbnCode = "0-19-222808-2",
                Title = ".Net 5 Overview",
                PublishedDate = new DateTime(2021, 1, 1),
                Id = Guid.Parse("{AF62A530-255D-4FAD-801B-A4BB99C18D69}"),
                Authors = new List<Author>()
                {
                    new()
                    {
                        Id = Guid.Parse("{E45202D7-F92D-4CB7-9302-A5EBEE99B1C7}"),
                        FirstName = "Adebayo",
                        LastName = "Sogo",

                    },
                    new()
                    {
                        Id = Guid.Parse("{FD8A6434-6485-4CED-8D17-03FFCFC4D7FF}"),
                        FirstName = "Samson",
                        LastName = "Godwin",

                    }
                },
                Category = new Category()
                {
                    Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                    Title = "Software Engineering"
                }



            }
            };

            var mockBookRepository = new Mock<IAsyncRepository<Books>>();

            mockBookRepository.Setup(repo => repo.GetAll(It.IsAny<int>(), It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync((int page, int size, CancellationToken _) => books.Skip((page - 1) * size).Skip(size).ToList());

            mockBookRepository.Setup(repo => repo.Create(It.IsAny<Books>(), CancellationToken.None))
                .ReturnsAsync((Books book) =>
                {
                    books.Add(book);
                    return book;
                });


            // getBy
            mockBookRepository.Setup(repo => repo.GetById(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((string id, CancellationToken _) =>
                {
                    var book = books.Find(x => x.Id == Guid.Parse(id));
                    return book;
                });


            // delete
            mockBookRepository.Setup(repo => repo.Delete(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((string id, CancellationToken _) =>
                {
                    var book = books.Find(x => x.Id == Guid.Parse(id));
                    if (book != null)
                    {
                        book.IsDeleted = true;
                        return true;
                    }
                    return false;
                });

            //get by
            mockBookRepository.Setup(repo =>
                    repo.GetBy(It.IsAny<Expression<Func<Books, bool>>>(), CancellationToken.None))
                .ReturnsAsync((Func<Books, bool> p, CancellationToken _) => books.Where(p).ToList());


            //update
            mockBookRepository.Setup(repo => repo.Update(It.IsAny<Books>(), CancellationToken.None))
                .ReturnsAsync((Books book, CancellationToken _) =>
                {
                    var exist = books.Find(x => x.Id == book.Id);
                    if (exist != null)
                    {
                        exist.IsbnCode = book.IsbnCode;
                        exist.PublishedDate = book.PublishedDate;
                        exist.Title = book.Title;

                        return true;


                    }

                    return false;
                });


            return mockBookRepository;
        }
    }
}