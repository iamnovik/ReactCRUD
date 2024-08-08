using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IBookRepository : IBaseRepository<BookEntity, Guid>
{
    
}