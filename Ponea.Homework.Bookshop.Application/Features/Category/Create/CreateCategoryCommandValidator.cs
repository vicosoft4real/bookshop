using FluentValidation;

namespace Ponea.Homework.Bookshop.Application.Features.Category.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Ponea.Homework.Bookshop.Application.Features.Category.Create.CreateCategoryCommand}</cref>
    /// </seealso>
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryCommandValidator"/> class.
        /// </summary>
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}