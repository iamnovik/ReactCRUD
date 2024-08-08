using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations;

public class BookRepository : BaseRepository<BookEntity,Guid>, IBookRepository
{
    public BookRepository(BookStoreDbContext context) : base(context)
    {
    }

   
}