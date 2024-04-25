using BookStore.API.DTOs;
using BookStore.Domain.Models;
using BookStore.UseCases.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService service)
        {
            _booksService = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookGetDTO>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(b => new BookGetDTO(b.Id,b.Title,b.Description,b.Price)).ToList();
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BookCreateDTO book)
        {
            Result<Book> result = Book.Create(Guid.NewGuid(), book.Tittle, book.Description, book.Price);
            if(result.IsSuccess)
            {
                await _booksService.CreateBook(result.Value);
                return Ok(result.Value);
            }
            else 
            {
                return BadRequest(result.Error);
            }
        }
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateBooks(Guid id, [FromBody] BookCreateDTO book)
        {
            var bookId = await _booksService.UpdateBook(id, book.Tittle, book.Description, book.Price);
            return Ok(bookId);
        }
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _booksService.DeleteBook(id);
            return Ok(bookId);
        }
    }
}
