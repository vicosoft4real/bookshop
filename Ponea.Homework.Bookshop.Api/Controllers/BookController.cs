using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create;
using Ponea.Homework.Bookshop.Application.Features.Book.Commands.Delete;
using Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update;
using Ponea.Homework.Bookshop.Application.Features.Book.Query;

namespace Ponea.Homework.Bookshop.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBooks(int page = 1, int size = 10)
        {
            var books = await mediator.Send(new GetAllBooksQuery { Page = page, Size = size });

            return Ok(books);
        }


        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await mediator.Send(new GetBookByIdQuery { Id = id });

            return Ok(book);
        }


        /// <summary>
        /// Gets the name of the book by category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookByCategoryName(string name)
        {
            var book = await mediator.Send(new GetBookByCategoryName { CategoryName = name });

            return Ok(book);
        }

        /// <summary>
        /// Gets the book by author.
        /// </summary>
        /// <param name="authorName">Name of the author.</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{authorName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookByAuthor(string authorName)
        {
            var book = await mediator.Send(new GetBookByAuthorNameQuery { AuthName = authorName });

            return Ok(book);
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="updateBookCommand">The update book command.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand updateBookCommand)
        {
            var book = await mediator.Send(updateBookCommand);
            if (book.Succeed)
                return Ok(book);
            return BadRequest(book);
        }


        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="createBook">The create book.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand createBook)
        {
            var book = await mediator.Send(createBook);
            if (book.Succeed)
                return Ok(book);
            return BadRequest(book);
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="deleteBook">The delete book.</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook([FromBody] DeleteBookCommand deleteBook)
        {
            var isDeleted = await mediator.Send(deleteBook);
            if (isDeleted)
                return Ok();
            return BadRequest();
        }
    }
}
