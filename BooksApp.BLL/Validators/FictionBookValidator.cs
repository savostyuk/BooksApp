using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.BLL.Validators;

public class FictionBookValidator : AbstractValidator<FictionBook>
{
    public FictionBookValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Name is required.")
            .MinimumLength(3).WithMessage("The Name must be greater than 3 characters.");
        RuleFor(x => x.Author)
            .Length(10, 200).WithMessage("The Author must be from 10 to 200 characters.");
        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(0).WithMessage("The Year must be a valid positive number."); ;
        RuleFor(x => x.Genre)
            .Length(1, 50).WithMessage("The Genre must be from 1 to 50 characters.");
        RuleFor(x => x.AgeRestrictions)
            .InclusiveBetween(0, 100).WithMessage("Age must be between 0 and 100");
    }
}
