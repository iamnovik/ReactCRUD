using BookStore.BLL.DTO;
using FluentValidation;

namespace BookStore.BLL.Validators;

public class BookDtoValidator : AbstractValidator<CreateBookDto>
{
    public BookDtoValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty()
            .MaximumLength(CreateBookDto.MaxTitleLength)
            .WithMessage("Title is empty");
        
        RuleFor(b => b.Description)
            .NotEmpty()
            .WithMessage("Description is empty");
    }
}