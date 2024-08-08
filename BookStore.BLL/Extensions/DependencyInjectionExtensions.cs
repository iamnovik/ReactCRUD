using System.Reflection;
using BookStore.BLL.DTO;
using BookStore.BLL.Services.Implementations;
using BookStore.BLL.Services.Interfaces;
using BookStore.BLL.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.BLL.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<AbstractValidator<CreateBookDto>, BookDtoValidator>();
        return services;
    }
}