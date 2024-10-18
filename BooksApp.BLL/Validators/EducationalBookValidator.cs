using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.BLL.Validators;

public class EducationalBookValidator : AbstractValidator<EducationalBook>
{
    public EducationalBookValidator ()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Name is required.")
            .MinimumLength(3).WithMessage("The Name must be greater than 3 characters.");
        RuleFor(x => x.Author)
            .Length(10, 200).WithMessage("The Author must be from 10 to 200 characters.");
        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(0).WithMessage("The Year must be a valid positive number."); ;
        RuleFor(x => x.Speciality)
            .Length(10, 100).WithMessage("The Speciality must be from 10 to 100 characters.");
        RuleFor(x => x.Level)
            .MaximumLength(50).WithMessage("The Author name cannot exceed 50 characters.");
    }
}
