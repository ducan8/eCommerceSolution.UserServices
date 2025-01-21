using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6);
            RuleFor(temp => temp.PersonName)
                .NotEmpty().WithMessage("Person name is required").
                Length(1, 50);
            RuleFor(temp => temp.Gender)
                .NotEmpty().WithMessage("Gender is required")
                .IsInEnum().WithMessage("Invalid gender");
        }
    }
}
