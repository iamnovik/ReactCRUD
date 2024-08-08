using AutoMapper;
using BookStore.BLL.DTO;
using DAL.Entities;

namespace BookStore.BLL.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookEntity, ReadBookDto>();
        CreateMap<UpdateBookDto, BookEntity>();
        CreateMap<CreateBookDto, BookEntity>();
    }
    
}