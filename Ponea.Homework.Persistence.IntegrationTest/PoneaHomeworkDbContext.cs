using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ponea.Homework.Bookshop.Application.Contracts.Identity;
using Ponea.Homework.Bookshop.Domain.Entities;
using Ponea.Homework.Bookshop.Persistence;
using Shouldly;
using Xunit;

namespace Ponea.Homework.Persistence.IntegrationTest
{
    public class PoneaHomeworkDbContext
    {
        private readonly PoneaBookshopDbContext poneaBookshopDbContext;
        private readonly Mock<ILoggedInUserService> loggedInUserMock;
        private readonly string loggedInUserId;
        public PoneaHomeworkDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<PoneaBookshopDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            loggedInUserId = "00000000-0000-0000-0000-000000000000";
            loggedInUserMock = new Mock<ILoggedInUserService>();
            loggedInUserMock.Setup(m => m.UserId).Returns(loggedInUserId);

            poneaBookshopDbContext = new PoneaBookshopDbContext(dbContextOptions, loggedInUserMock.Object);
        }

        [Fact]
        public async Task Save_Book_Set_CreatedBy()
        {
            var book = new Books()
            {
                IsbnCode = "0-19-853888-2", // exist isbn
                Title = "Advance animation",
                CategoryId = Guid.Parse("{4B8C58BA-0781-4922-9BDD-9F1FC6414DDD}"),
                PublishedDate = DateTime.Now

            };

            poneaBookshopDbContext.Books.Add(book);
            await poneaBookshopDbContext.SaveChangesAsync(CancellationToken.None);

            book.CreatedBy.ShouldBe(loggedInUserId);
        }
    }
}