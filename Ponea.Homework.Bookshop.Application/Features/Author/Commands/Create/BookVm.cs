namespace Ponea.Homework.Bookshop.Application.Features.Author.Commands.Create
{
    /// <summary>
    /// 
    /// </summary>
    public class BookVm
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the isbn code.
        /// </summary>
        /// <value>
        /// The isbn code.
        /// </value>
        public string IsbnCode { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public string CategoryId { get; set; }
    }
}