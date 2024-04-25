using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStore.Domain.Models;
using BookStore.DataAccess.Entities;
namespace BookStore.DataAccess.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Title)
                .HasMaxLength(Book.MAX_TITTLE_LENGTH)
                .IsRequired();
            builder.Property(b => b.Description)
                .HasMaxLength(Book.MAX_DESCRIPTION_LENGTH)
                .IsRequired();
        }
    }
}
