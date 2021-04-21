using FluentValidation;

namespace Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create.CreateAuthorCommand}</cref>
    /// </seealso>
    public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAuthorCommandValidation"/> class.
        /// </summary>
        public CreateAuthorCommandValidation()
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The {PropertyName} is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}