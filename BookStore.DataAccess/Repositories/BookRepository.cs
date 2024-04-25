using BookStore.Domain.Models;
using BookStore.UseCases.Interfaces;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public BookRepository(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Book>> Get()
        {
            var bookEntities = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
            var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Value).ToList();
            return books;
        }
        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
            };
            await _dbContext.Books.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();
            return bookEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string tittle, string description, decimal? price)
        {
            await _dbContext.Books
                .Where(x => x.Id == id)
                    .ExecuteUpdateAsync(s => s
                                            .SetProperty(b => b.Title, b => tittle)
                                            .SetProperty(b => b.Description, b => description)
                                            .SetProperty(b => b.Price, b => price));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Books
                 .Where(x => x.Id == id)
                    .ExecuteDeleteAsync();
            return id;
        }
    }
}
