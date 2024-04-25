using CSharpFunctionalExtensions;

namespace BookStore.Domain.Models
{
    public class Book
    {
        public const int MAX_TITTLE_LENGTH = 100;
        public const int MAX_DESCRIPTION_LENGTH = 250;
        public Book(Guid guid, string title, string description, decimal? price)
        {
            Id = guid;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal? Price { get; }
        public static CSharpFunctionalExtensions.Result<Book> Create(Guid guid, string title, string description, decimal? price)
        {
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITTLE_LENGTH)
            {
                return Result.Failure<Book>($"{nameof(title)} cannot be null or bigger than {MAX_TITTLE_LENGTH} characters");
            }
            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
            {
                return Result.Failure<Book>($"{nameof(description)} cannot be null or bigger than {MAX_DESCRIPTION_LENGTH}");
            }
            var Book = new Book(guid, title, description, price);
            return Result.Success(Book);
        }
    }
}
