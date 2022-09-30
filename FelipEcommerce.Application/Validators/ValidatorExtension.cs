using FluentValidation;

namespace FelipEcommerce.Application.Validators
{
    public static class ValidatorExtension
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Password must me at least 6 characters")
                .Matches("[A-Z]").WithMessage("Password must contain one upper case letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lower case letter")
                .Matches("[0-9]").WithMessage("Password must contain number")
                .Matches("[^a-zA-Z-0-9]").WithMessage("Password must contain a non alphanumeric");

            return options;
        }
    }
}