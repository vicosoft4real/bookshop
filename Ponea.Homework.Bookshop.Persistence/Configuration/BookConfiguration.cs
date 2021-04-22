using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ponea.Homework.Bookshop.Domain.Entities;

namespace Ponea.Homework.Bookshop.Persistence.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Ponea.Homework.Bookshop.Domain.Entities.Books}</cref>
    /// </seealso>
    public class BookConfiguration : IEntityTypeConfiguration<Books>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>
        /// .
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.IsbnCode).IsRequired();




        }
    }
}