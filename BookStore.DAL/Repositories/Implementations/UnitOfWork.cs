using DAL.Context;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations;

public class UnitOfWork(BookStoreDbContext context) : IUnitOfWork
{
    private BookRepository? _bookRepository;

    public IBookRepository Books => _bookRepository ??= new BookRepository(context);
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    private bool _disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }

            this._disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}