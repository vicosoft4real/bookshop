using MediatR;
using Ponea.Homework.Bookshop.Application.Contracts.Common;

namespace Ponea.Homework.Bookshop.Application.Features.Category.Create
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{(System.Boolean Succeed, System.String id, System.String[] ValidationError)}</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>Ponea.Homework.Bookshop.Application.Contracts.Common.IMapFrom{Ponea.Homework.Bookshop.Domain.Entities.Category}</cref>
    /// </seealso>
    public class CreateCategoryCommand : IRequest<(bool Succeed, string id, string[] ValidationError)>, IMapFrom<Domain.Entities.Category>
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}