using BookStore.Domain.Models;
using BookStore.UseCases.Interfaces;
namespace BookStore.Application
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        public BooksService(IBooksRepository bookRepository)
        {
            _repository = bookRepository;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _repository.Get();
        }
        public async Task<Guid> CreateBook(Book book)
        {
            return await _repository.Create(book);
        }
        public async Task<Guid> UpdateBook(Guid id, string tittle, string description, decimal? price)
        {
            return await _repository.Update(id, tittle, description, price);
        }
        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
