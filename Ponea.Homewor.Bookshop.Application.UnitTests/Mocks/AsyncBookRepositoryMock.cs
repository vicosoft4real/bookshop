using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Moq;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Application.UnitTests.Mocks
{
    public class AsyncBookRepositoryMock
    {
        public static Mock<IAsyncRepository<Domain.Entities.Books>> GetBooksRepository()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                    Title = "Software Engineering"
                },
                new Category()
                {
                    Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                    Title = "Software Engineering"
                },
                new Category()
                {
                    Id = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                    Title = "Software Engineering"
                }
            };
            var books = new List<Domain.Entities.Books>()
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

                        },

                    },




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




            }
            };

            var mockBookRepository = new Mock<IAsyncRepository<Domain.Entities.Books>>();

            mockBookRepository.Setup(repo => repo.GetAll(It.IsAny<int>(), It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync((int page, int size, CancellationToken _) => books.Skip((page - 1) * size).Take(size).ToList());

            mockBookRepository.Setup(repo => repo.Create(It.IsAny<Domain.Entities.Books>(), CancellationToken.None))
                .ReturnsAsync((Domain.Entities.Books book, CancellationToken _) =>
                {
                    var existCategory = categories.FirstOrDefault(x => x.Id == book.CategoryId);
                    if (existCategory != null)
                    {
                        books.Add(book);
                        book.Id = Guid.NewGuid();
                    }

                    return book;
                });


            // getBy id
            mockBookRepository.Setup(repo => repo.GetById(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync((Guid id, CancellationToken _) =>
                {
                    var book = books.FirstOrDefault(x => x.Id.Equals(id));
                    return book;
                });


            // delete
            mockBookRepository.Setup(repo => repo.Delete(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync((Guid id, CancellationToken _) =>
                {
                    var book = books.FirstOrDefault(x => x.Id.Equals(id));
                    if (book != null)
                    {
                        book.IsDeleted = true;
                        return true;
                    }
                    return false;
                });

            //get by
            mockBookRepository.Setup(repo =>
                    repo.GetBy(It.IsAny<Expression<Func<Domain.Entities.Books, bool>>>(), CancellationToken.None))
                .ReturnsAsync((Expression<Func<Domain.Entities.Books, bool>> p, CancellationToken _) => books.AsQueryable().Where(p).ToList());

            //first or default
            mockBookRepository.Setup(repo =>
                    repo.GetFirstOrDefault(It.IsAny<Expression<Func<Domain.Entities.Books, bool>>>(), CancellationToken.None))
                .ReturnsAsync((Expression<Func<Domain.Entities.Books, bool>> p, CancellationToken _) => books.AsQueryable().FirstOrDefault(p));

            //update
            mockBookRepository.Setup(repo => repo.Update(It.IsAny<Domain.Entities.Books>(), CancellationToken.None))
                .ReturnsAsync((Domain.Entities.Books book, CancellationToken _) =>
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