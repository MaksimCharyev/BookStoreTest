using BookStore.Domain.Models;

namespace BookStore.UseCases.Interfaces
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string tittle, string description, decimal? price);
    }
}