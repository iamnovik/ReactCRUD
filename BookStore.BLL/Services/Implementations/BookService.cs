using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BookStore.BLL.Services.Implementations;
public class BookService(IMapper mapper, IUnitOfWork unitOfWork) : IBookService
{
    public async Task<ReadBookDto?> CreateBookAsync(CreateBookDto bookDto, CancellationToken cancellationToken = default)
    {
        if (bookDto == null) throw new ArgumentNullException(nameof(bookDto));
          
        var book = mapper.Map<BookEntity>(bookDto);
        var createdBook = await unitOfWork.Books.AddAsync(book, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadBookDto>(createdBook);
    }
    

    public async Task<IEnumerable<ReadBookDto>> GetBooksAsync(CancellationToken cancellationToken = default)
    {
        var categories = await unitOfWork.Books.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadBookDto>>(categories);
    }

    public async Task<ReadBookDto?> UpdateBookAsync(Guid id, UpdateBookDto bookDto, CancellationToken cancellationToken = default)
    {
        if (bookDto == null) throw new ArgumentNullException(nameof(bookDto));
        
        var book = mapper.Map<BookEntity>(bookDto);
        var bookDb = await unitOfWork.Books.GetByIdAsync(id, cancellationToken);
        if (bookDb == null)
        {
            return null;
        }

        bookDb.Title = book.Title;
        bookDb.Description = book.Description;
        bookDb.Price = book.Price;
        
        await unitOfWork.Books.Update(bookDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadBookDto>(bookDb);
    }

    public async Task<bool> DeleteBookAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await unitOfWork.Books.GetByIdAsync(id, cancellationToken);
        if (book == null)
        {
            return false;
        }

        await unitOfWork.Books.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ReadBookDto?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await unitOfWork.Books.GetByIdAsync(id, cancellationToken);
        return book == null ? null : mapper.Map<ReadBookDto>(book);
    }
}