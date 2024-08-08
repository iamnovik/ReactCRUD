namespace DAL.Repositories.Interfaces;

public interface IUnitOfWork
{
    IBookRepository Books { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}