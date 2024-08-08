using BookStore.BLL.DTO;

namespace BookStore.BLL.Services.Interfaces;

public interface IBookService
{
    Task<ReadBookDto?> CreateBookAsync(
        CreateBookDto orderDto, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadBookDto>> GetBooksAsync(
        CancellationToken cancellationToken = default);
    
    Task<ReadBookDto?> GetBookByIdAsync(
        Guid id, CancellationToken cancellationToken = default);
    
    Task<ReadBookDto?> UpdateBookAsync(
        Guid id, UpdateBookDto orderDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteBookAsync(
        Guid id, CancellationToken cancellationToken = default);


}