using BookStore.BLL.DTO;
using BookStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellationToken = default)
    {
        var books = await bookService.GetBooksAsync(cancellationToken);
        
        return Ok(books);

    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await bookService.GetBookByIdAsync(id, cancellationToken);

        if (book is null)
        {
            return NotFound();
        }
        
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(
        [FromBody] CreateBookDto model, CancellationToken cancellationToken = default)
    {
        var book = await bookService.CreateBookAsync(model, cancellationToken);

        if (book is null)
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBookAsync(
        Guid id, [FromBody] UpdateBookDto model, CancellationToken cancellationToken = default)
    {
        var book = await bookService.UpdateBookAsync(id, model, cancellationToken);

        if (book is null)
        {
            return BadRequest();
        }
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBookAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var isSuccess = await bookService.DeleteBookAsync(id, cancellationToken);

        if (!isSuccess)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}