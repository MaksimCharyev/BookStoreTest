using BookStore.Domain.Models;
namespace BookStore.UseCases.Interfaces
{
    public interface IBooksRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string tittle, string description, decimal? price);
    }
}