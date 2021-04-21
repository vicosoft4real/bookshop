using FluentValidation;

namespace Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Ponea.Homework.Bookshop.Application.Features.Book.Commands.Update.UpdateBookCommand}</cref>
    /// </seealso>
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBookValidator"/> class.
        /// </summary>
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The {PropertyName} is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} is required");
            RuleFor(x => x.IsbnCode).NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}