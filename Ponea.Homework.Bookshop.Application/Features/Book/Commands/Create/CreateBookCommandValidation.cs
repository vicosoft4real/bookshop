using FluentValidation;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateBookCommandValidation : AbstractValidator<CreateBookCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookCommandValidation"/> class.
        /// </summary>
        public CreateBookCommandValidation()
        {
            RuleFor(x => x.IsbnCode).NotEmpty().WithMessage("The {PropertyName} code is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithErrorCode("The book category is required");
        }
    }
}